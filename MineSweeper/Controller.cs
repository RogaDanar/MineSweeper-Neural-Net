﻿namespace MineSweeper
{
    using NeuralNet.Genetics;
    using NeuralNet.Helpers;
    using NeuralNet.Network;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    public class Controller
    {
        private readonly Rand _rand = Rand.Generator;

        private Settings _settings;

        private Main _mainForm;
        private bool _done;
        private bool _runSimulation;
        private bool _fast;
        private bool _setupNeeded;

        private List<Sweeper> _sweepers;
        private List<List<double>> _mines;
        private GeneticAlgorithm _genetics;
        private Population _population;
        private int _ticksDone;

        public Controller()
        {
            _done = false;
            _runSimulation = false;
            _setupNeeded = true;
            _settings = new Settings();

            _mainForm = new Main(_settings);
            _mainForm.FormClosing += mainFormClosing;
            _mainForm.FormClosed += mainFormClosed;
            _mainForm.SettingsChanged += mainFormSettingsChanged;
            _mainForm.StartButton.Click += mainFormStartButtonClick;
            _mainForm.FastButton.Click += mainFormFastButtonClick;

            var uiThread = new Thread(() => {
                Application.Run(_mainForm);
            });
            uiThread.Start();

            StartSimulation();
        }

        public void Setup()
        {
            _genetics = new GeneticAlgorithm(_settings.MutationRate, _settings.CrossoverRate, _settings.MaxPerturbation);
            _sweepers = createSweepers(_settings.SweeperCount).ToList();
            _mines = createMines(_settings.MineCount).ToList();
            var sweeperWeightCount = _sweepers.First().Brain.AllWeightsCount();
            _population = new Population(_settings.SweeperCount, sweeperWeightCount);
            initializeBrains();
        }

        public void StartSimulation()
        {
            _ticksDone = 0;
            while (!_done)
            {
                if (_runSimulation)
                {
                    Update();
                    updateUI();
                }
            }
        }

        private void updateUI()
        {
            if (_runSimulation)
            {
                try
                {
                    if (_ticksDone == 0)
                    {
                        _mainForm.Invoke((MethodInvoker)delegate { _mainForm.UpdateGraph(_population); });
                    }

                    if (!_fast)
                    {
                        _mainForm.Invoke((MethodInvoker)delegate { _mainForm.UpdateDisplay(_sweepers, _mines); });
                    }
                    _mainForm.Invoke((MethodInvoker)delegate { _mainForm.UpdateStats(_population); });
                }
                catch (ObjectDisposedException) { }
            }
        }

        public void Update()
        {
            if (_ticksDone < _settings.Ticks)
            {
                for (int i = 0; i < _sweepers.Count; i++)
                {
                    var sweeper = _sweepers[i];
                    sweeper.Update(_mines);
                    var foundMine = sweeper.CheckForMine(_settings.MineSize + _settings.SweeperSize);
                    if (foundMine != null)
                    {
                        var mine = _mines.Single(x => matchVectors(x, foundMine));
                        _mines.Remove(mine);
                        _mines.AddRange(createMines(1));
                        sweeper.Fitness++;
                    }
                }
                _population.UpdateStats();
                _ticksDone++;
            }
            else
            {
                NextGeneration();
                _ticksDone = 0;
            }
        }

        public void NextGeneration()
        {
            _population = _genetics.NextGeneration(_population);

            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.Genome = _population.Genomes[i];
                var position = getRandomPosition();
                var rotation = getRandomRotation();
                _sweepers[i].Initialize(position, rotation);
            }
            _mines = createMines(_mines.Count).ToList();
        }

        private IEnumerable<List<double>> createMines(int numberOfMines)
        {
            for (int i = 0; i < numberOfMines; i++)
            {
                var mine = getRandomPosition();
                yield return mine;
            }
        }

        private void initializeBrains()
        {
            for (int i = 0; i < _sweepers.Count; i++)
            {
                _sweepers[i].Brain.Genome = _population.Genomes[i];
            }
        }

        private IEnumerable<Sweeper> createSweepers(int numberOfSweepers)
        {
            for (int i = 0; i < numberOfSweepers; i++)
            {
                var position = getRandomPosition();
                var rotation = getRandomRotation();
                var brain = new FeedforwardNetwork(Sweeper.BrainInputs, Sweeper.BrainOutputs, _settings.HiddenLayers, _settings.HiddenLayerNeurons);
                yield return new Sweeper(position, rotation, _settings.DrawWidth, _settings.DrawHeight, brain);
            }
        }

        private bool matchVectors(List<double> vector, List<double> vectorToMatch)
        {

            if (vector.Count == vectorToMatch.Count)
            {
                for (int i = 0; i < vector.Count; i++)
                {
                    if (!vector[i].Equals(vectorToMatch[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private double getRandomRotation()
        {
            var rotation = _rand.NextDouble() * Math.PI * 2;
            return rotation;
        }

        private List<double> getRandomPosition()
        {
            var position = new List<double> { _rand.NextDouble(0, _settings.DrawWidth), _rand.NextDouble(0, _settings.DrawHeight) };
            return position;
        }

        private void mainFormFastButtonClick(object sender, EventArgs e)
        {
            _fast = !_fast;
        }

        private void mainFormStartButtonClick(object sender, EventArgs e)
        {
            var startRun = !_runSimulation;
            if (startRun && _setupNeeded)
            {
                Setup();
                _setupNeeded = false;
            }
            _runSimulation = startRun;
        }

        private void mainFormSettingsChanged(object sender, Settings settings)
        {
            _settings = settings;

            _runSimulation = false;
            _setupNeeded = true;
        }

        private void mainFormClosed(object sender, FormClosedEventArgs e)
        {
            _done = true;
        }

        private void mainFormClosing(object sender, FormClosingEventArgs e)
        {
            _runSimulation = false;
        }
    }
}
