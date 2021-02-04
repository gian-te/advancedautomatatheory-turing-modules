using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TwoWayAccepter.Entities;

namespace TwoWayAccepter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ViewModel _viewModel;
        //public int omegaIndex { get { return _viewModel.Diagnostics.OmegaIndex; } set { _viewModel.Diagnostics.OmegaIndex = value; } }
        public int stateCounter = 1;
        public MainWindow()
        {
            InitializeComponent();
            Rebind();
            Init();

            Dispatcher.Invoke(() =>
            {
                Task.Run(() => { Thread.Sleep(1000); HighlightCurrentStateInDatagrid(); });
            });
        }

        private void Init()
        {
            // test case 1 - random
            //_viewModel.States.Add(new State() { StateName = "1", Module = "shR-2" });
            //_viewModel.States.Add(new State() { StateName = "2", Module = "shL-1" });
            //_viewModel.States.Add(new State() { StateName = "3", Module = "shR-1" });
            //_viewModel.States.Add(new State() { StateName = "4", Module = "const-1" });
            //_viewModel.States.Add(new State() { StateName = "5", Module = "copy-2" });
            //_viewModel.States.Add(new State() { StateName = "6", Module = "move 1,1" });
            //_viewModel.Omega = "#111#000#";

            // test case 2 - swappy
            //_viewModel.States.Add(new State() { StateName = "1", Module = "shR-2" });
            //_viewModel.States.Add(new State() { StateName = "2", Module = "copy-2" });
            //_viewModel.States.Add(new State() { StateName = "3", Module = "shL-2" });
            //_viewModel.States.Add(new State() { StateName = "4", Module = "move 1,2" });
            //_viewModel.Omega = "#1111#11#";

            // test case 3 - geometric series
            //_viewModel.States.Add(new State() { StateName = "1", Module = "const-1" });
            //_viewModel.States.Add(new State() { StateName = "2", Module = "shR-1" });
            //_viewModel.States.Add(new State() { StateName = "3", Module = "copy-1" });
            //_viewModel.States.Add(new State() { StateName = "4", Module = "const-2" });
            //_viewModel.States.Add(new State() { StateName = "5", Module = "shL-1" });
            //_viewModel.States.Add(new State() { StateName = "6", Module = "mult" });
            //// pattern
            //_viewModel.States.Add(new State() { StateName = "7", Module = "shR-1" });
            //_viewModel.States.Add(new State() { StateName = "8", Module = "copy-1" });
            //_viewModel.States.Add(new State() { StateName = "9", Module = "const-2" });
            //_viewModel.States.Add(new State() { StateName = "10", Module = "shL-1" });
            //_viewModel.States.Add(new State() { StateName = "11", Module = "mult" });
            ////
            //_viewModel.States.Add(new State() { StateName = "12", Module = "shR-1" });
            //_viewModel.States.Add(new State() { StateName = "13", Module = "copy-1" });
            //_viewModel.States.Add(new State() { StateName = "14", Module = "const-2" });
            //_viewModel.States.Add(new State() { StateName = "15", Module = "shL-1" });
            //_viewModel.States.Add(new State() { StateName = "16", Module = "mult" });
            ////
            //_viewModel.States.Add(new State() { StateName = "17", Module = "shR-1" });
            //_viewModel.States.Add(new State() { StateName = "18", Module = "copy-1" });
            //_viewModel.States.Add(new State() { StateName = "19", Module = "const-2" });
            //_viewModel.States.Add(new State() { StateName = "20", Module = "shL-1" });
            //_viewModel.States.Add(new State() { StateName = "21", Module = "mult" });
            ////
            //_viewModel.States.Add(new State() { StateName = "22", Module = "shR-1" });
            //_viewModel.States.Add(new State() { StateName = "23", Module = "copy-1" });
            //_viewModel.States.Add(new State() { StateName = "24", Module = "const-2" });
            //_viewModel.States.Add(new State() { StateName = "25", Module = "shL-1" });
            //_viewModel.States.Add(new State() { StateName = "26 ", Module = "mult" });
            //_viewModel.Omega = "####";


            // exam
            _viewModel.States.Add(new State() { StateName = "1", Module = "shR-1" });
            _viewModel.States.Add(new State() { StateName = "2", Module = "const-1" });
            _viewModel.States.Add(new State() { StateName = "3", Module = "copy-1" });
            //_viewModel.States.Add(new State() { StateName = "4", Module = "shR-1" });
            _viewModel.States.Add(new State() { StateName = "4", Module = "shL-1" });
            _viewModel.States.Add(new State() { StateName = "5", Module = "minus" });
            _viewModel.States.Add(new State() { StateName = "6", Module = "shR-1" });
            _viewModel.States.Add(new State() { StateName = "7", Module = "copy-1" });

            _viewModel.States.Add(new State() { StateName = "8", Module = "const-1" });
            _viewModel.States.Add(new State() { StateName = "9", Module = "copy-1" });
            _viewModel.States.Add(new State() { StateName = "10", Module = "shL-1" });
            _viewModel.States.Add(new State() { StateName = "11", Module = "ifEQ-16" });

            _viewModel.States.Add(new State() { StateName = "12", Module = "copy-1" });
                                                              
            _viewModel.States.Add(new State() { StateName = "13", Module = "shL-2" });
            _viewModel.States.Add(new State() { StateName = "14", Module = "ifEQ-2" });
            _viewModel.States.Add(new State() { StateName = "15", Module = "shL-1" });
            _viewModel.States.Add(new State() { StateName = "16", Module = "const-1" });
            _viewModel.States.Add(new State() { StateName = "17", Module = "shL-1" });
            _viewModel.States.Add(new State() { StateName = "18", Module = "ifEQ-19" });
            _viewModel.States.Add(new State() { StateName = "19", Module = "halt" });
            _viewModel.Omega = "#5#";

            _viewModel.InitialState = stateCounter.ToString();
            _viewModel.Diagnostics.CurrentSymbol = _viewModel.Omega[0].ToString();
        }

        private void Rebind()
        {
            _viewModel = new ViewModel();
            _viewModel.Diagnostics.OmegaIndex = 0;
            this.DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.States.Add(new State() { StateName = "*state name*", Module = "*module*" });
        }

        /// <summary>
        /// Contains the meat of the automatic transition logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //#region Validation
            //if (string.IsNullOrEmpty(_viewModel.Omega))
            //{
            //    MessageBox.Show("Input string cannot be blank. Enter a value for Omega.");
            //    return;
            //}
            //if (_viewModel.States.Count == 0)
            //{
            //    MessageBox.Show("States cannot be empty. Add some states.");
            //    return;
            //}
            //if (string.IsNullOrEmpty(_viewModel.InitialState))
            //{
            //    MessageBox.Show("Initial state cannot be blank. Enter an initial state.");
            //    return;
            //}

            //#endregion

            //_viewModel.Playing = true;
            //SetInitialState();

            //Task.Run(() =>
            //{
            //    for (; omegaIndex < _viewModel.Omega.Length;)
            //    {
            //        if (_viewModel.Stopped)
            //        {
            //            break;
            //        }
            //        HighlightCurrentStateInDatagrid();

            //        var letter = _viewModel.Omega[omegaIndex];
            //        var symbol = letter.ToString();

            //        UpdateCurrentSymbolLabel(symbol);
            //        UpdateCurrentStateLabel();


            //        if (IsAccepted() || IsRejected())
            //        {
            //            break;
            //        }


            //        //EvaluateNextState(symbol);
            //        UpdateProcessedSymbolLabel(_viewModel.Omega.Substring(1, omegaIndex));
            //        UpdateCurrentStateLabel();
            //        HighlightCurrentStateInDatagrid();
            //        //UpdateNextPossibleStates();
            //        //IncrementOrDecrementOmegaIndex();
            //        CheckIfFinished();
            //        Thread.Sleep(200);
            //    }


            //    _viewModel.Diagnostics.CurrentStateName = _viewModel.Diagnostics.CurrentState.StateName;

            //    _viewModel.Playing = false;
            //});
        }

        /// <summary>
        /// Manual Step
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            #region Validation
            if (string.IsNullOrEmpty(_viewModel.Omega))
            {
                MessageBox.Show("Input string cannot be blank. Enter a value for Omega.");
                return;
            }
            if (_viewModel.States.Count == 0)
            {
                MessageBox.Show("States cannot be empty. Add some states.");
                return;
            }
            if (string.IsNullOrEmpty(_viewModel.InitialState))
            {
                MessageBox.Show("Initial state cannot be blank. Enter an initial state.");
                return;
            }

            #endregion

            SetInitialState();
            if (_viewModel.Diagnostics.OmegaIndex >= _viewModel.Omega.Length)
            {
                return;
            }

            var letter = _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex];
            var symbol = letter.ToString();

            UpdateCurrentSymbolLabel(symbol);

            UpdateCurrentStateLabel();

            if (IsAccepted() || IsRejected())
            {
                return;
            }

            EvaluateNextState(symbol);
            UpdateProcessedSymbolLabel(_viewModel.Omega.Substring(1, _viewModel.Diagnostics.OmegaIndex));
            UpdateCurrentStateLabel();
            HighlightCurrentStateInDatagrid();
            CheckIfFinished();


        }

        private void HighlightCurrentStateInDatagrid()
        {
            try
            {
                Dispatcher.Invoke(() =>
                {

                    var stateObj = _viewModel.States.Where(name => name.StateName.ToUpper() == _viewModel.Diagnostics._currentStateName.ToUpper()).FirstOrDefault();
                    if (stateObj == null)
                    {
                        return;
                    }
                    var index = _viewModel.States.IndexOf(stateObj);
                    dgStates.SelectedIndex = index;
                    DataGridRow row = (DataGridRow)dgStates.ItemContainerGenerator.ContainerFromIndex(index);
                    if (row == null)
                    {
                        return;
                    }
                    row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                });
            }
            catch
            {
                // swallow UI exception, if any
            }
        }



        private void UpdateCurrentStateLabel()
        {
            try
            {
                if (_viewModel.Diagnostics.CurrentState != null)
                {
                    _viewModel.Diagnostics.CurrentStateName = _viewModel.Diagnostics.CurrentState.StateName;

                }
            }
            catch
            {

            }
        }

        private void CheckIfFinished()
        {
            if (_viewModel.Diagnostics.CurrentState == null)
            {
                MessageBox.Show("Reached the last module");
            }
        }

        private void SetInitialState()
        {
            if (_viewModel.Diagnostics.CurrentState == null)
            {
                _viewModel.Diagnostics.CurrentState = _viewModel.States.Where(name => name.StateName == stateCounter.ToString()).FirstOrDefault();
            }
        }

        private bool IsAccepted()
        {
            return _viewModel.Diagnostics.CurrentState.StateName.ToUpper() == "ACCEPT";
        }

        private bool IsRejected()
        {
            return _viewModel.Diagnostics.CurrentState.StateName.ToUpper() == "REJECT";
        }

        private void UpdateCurrentSymbolLabel(string symbol)
        {
            _viewModel.Diagnostics.CurrentSymbol = symbol;
        }

        private void UpdateProcessedSymbolLabel(string subStr)
        {
            _viewModel.Diagnostics.ProcessedSymbols = subStr;
        }


        private void EvaluateNextState(string symbol)
        {
            var nextPossibleStates = new List<State>();
            bool overrideCounter = false;
            // todo: handle how to transition to next state if current state has many transitions.
            nextPossibleStates = _viewModel.States.Where(s => s.StateName == _viewModel.Diagnostics.CurrentState.StateName).ToList();
            //var targetStateName = nextPossibleStates.Where(state => state.K == symbol).Select(s => s.DestinationState).FirstOrDefault();
            if (_viewModel.Diagnostics.CurrentState.Module.Contains("const"))
            {
                var value = _viewModel.Diagnostics.CurrentState.Module.Split('-')[1];
                _viewModel.Omega = _viewModel.Omega.Insert(_viewModel.Diagnostics.OmegaIndex + 1, value);
                _viewModel.Omega = _viewModel.Omega.Insert(_viewModel.Diagnostics.OmegaIndex + 2, "#");

            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("shL"))
            {
                var value = _viewModel.Diagnostics.CurrentState.Module.Split('-')[1];
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex--;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    if (int.Parse(value) == j)
                    {
                        break;
                    }
                }
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("shR"))
            {
                var value = _viewModel.Diagnostics.CurrentState.Module.Split('-')[1];
                //for (int j = 0; j < int.Parse(value);)

                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    if (int.Parse(value) == j)
                    {
                        break;
                    }
                }
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("copy"))
            {
                // copy logic here
                // copy k-th item from the left
                var value = _viewModel.Diagnostics.CurrentState.Module.Split('-')[1];
                var currentIndex = _viewModel.Diagnostics.OmegaIndex;
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex--;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    if (int.Parse(value) == j)
                    {
                        break;
                    }
                }
                var symbols = "";
                for (int j = 0; j < 1;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        symbols += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
                _viewModel.Diagnostics.OmegaIndex++;
                _viewModel.Omega = _viewModel.Omega.Insert(_viewModel.Diagnostics.OmegaIndex, symbols + "#");
                _viewModel.Diagnostics.OmegaIndex--;
                _viewModel.Diagnostics.OmegaIndex += symbols.Length + 1;

            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("move"))
            {
                // move logic here
                var values = _viewModel.Diagnostics.CurrentState.Module.Split(' ')[1];
                var blocksToTheLeft = values.Split(',')[0];
                var blocksToTheRight = values.Split(',')[1];
                //var blocks = _viewModel.Omega.Split('#');

                var blocksToBeMoved = "";
                var currentIndex = _viewModel.Diagnostics.OmegaIndex;
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                        if (int.Parse(blocksToTheRight) > 1)
                        {
                            blocksToBeMoved += "#";
                        }
                    }
                    else
                    {
                        blocksToBeMoved += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (int.Parse(blocksToTheRight) == j)
                    {
                        break;
                    }
                }
                _viewModel.Omega = _viewModel.Omega.Remove(currentIndex, blocksToBeMoved.Length);
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex--;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    if (int.Parse(blocksToTheLeft) == j)
                    {
                        break;
                    }
                }
                while (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex + 1].ToString() != "#")
                {
                    _viewModel.Omega = _viewModel.Omega.Remove(_viewModel.Diagnostics.OmegaIndex + 1, 1);

                }
                _viewModel.Omega = _viewModel.Omega.Insert(_viewModel.Diagnostics.OmegaIndex + 1, blocksToBeMoved);
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("swap"))
            {
                // swap logic here
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("mult"))
            {
                // mult logic here
                var currentIndex = _viewModel.Diagnostics.OmegaIndex;
                var count = 0;
                var operand1 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand1 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }

                var operand2 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand2 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }


                // multiply
                var product = int.Parse(operand1) * int.Parse(operand2);

                _viewModel.Omega = _viewModel.Omega.Remove(currentIndex, count);
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
                _viewModel.Omega = _viewModel.Omega.Insert(currentIndex + 1, product.ToString() + "#");
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("add"))
            {
                // add logic here
                var currentIndex = _viewModel.Diagnostics.OmegaIndex;
                var count = 0;
                var operand1 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand1 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }

                var operand2 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand2 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }


                // add
                var product = int.Parse(operand1) + int.Parse(operand2);

                _viewModel.Omega = _viewModel.Omega.Remove(currentIndex, count);
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
                _viewModel.Omega = _viewModel.Omega.Insert(currentIndex + 1, product.ToString() + "#");
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("minus"))
            {
                // minus logic here
                var currentIndex = _viewModel.Diagnostics.OmegaIndex;
                var count = 0;
                var operand1 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand1 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }

                var operand2 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand2 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }


                // minus
                var product = int.Parse(operand1) - int.Parse(operand2);

                _viewModel.Omega = _viewModel.Omega.Remove(currentIndex, count);
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
                _viewModel.Omega = _viewModel.Omega.Insert(currentIndex + 1, product.ToString() + "#");
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("divide"))
            {
                // divide logic here
                var currentIndex = _viewModel.Diagnostics.OmegaIndex;
                var count = 0;
                var operand1 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand1 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }

                var operand2 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand2 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }


                // divide
                var product = int.Parse(operand1) / int.Parse(operand2);

                _viewModel.Omega = _viewModel.Omega.Remove(currentIndex, count);
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
                _viewModel.Omega = _viewModel.Omega.Insert(currentIndex + 1, product.ToString() + "#");
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("ifGT"))
            {
                // gt logic here
                // lt logic here
                var stateNumber = _viewModel.Diagnostics.CurrentState.Module.Split('-')[1];
                var currentIndex = _viewModel.Diagnostics.OmegaIndex;
                var count = 0;
                var operand1 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand1 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }

                var operand2 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand2 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }


                // ifGT
                var isLessThan = int.Parse(operand1) > int.Parse(operand2);
                if (isLessThan)
                {
                    stateCounter = int.Parse(stateNumber);
                    overrideCounter = true;
                }
                _viewModel.Omega = _viewModel.Omega.Remove(currentIndex, count);
                _viewModel.Omega = _viewModel.Omega.Insert(currentIndex + 1, "#");
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("ifGE"))
            {
                // ge logic here
                // lt logic here
                var stateNumber = _viewModel.Diagnostics.CurrentState.Module.Split('-')[1];
                var currentIndex = _viewModel.Diagnostics.OmegaIndex;
                var count = 0;
                var operand1 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand1 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }

                var operand2 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand2 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }


                // ifGE
                var isGreaterThanOrEqual = int.Parse(operand1) >= int.Parse(operand2);
                if (isGreaterThanOrEqual)
                {
                    stateCounter = int.Parse(stateNumber);
                    overrideCounter = true;
                }
                _viewModel.Omega = _viewModel.Omega.Remove(currentIndex, count);
                _viewModel.Omega = _viewModel.Omega.Insert(currentIndex + 1, "#");
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("ifLT"))
            {
                // lt logic here
                var stateNumber = _viewModel.Diagnostics.CurrentState.Module.Split('-')[1];
                var currentIndex = _viewModel.Diagnostics.OmegaIndex;
                var count = 0;
                var operand1 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand1 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }

                var operand2 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand2 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }


                // ifLT
                var isLessThan = int.Parse(operand1) < int.Parse(operand2);
                if (isLessThan)
                {
                    stateCounter = int.Parse(stateNumber);
                    overrideCounter = true;
                }
                _viewModel.Omega = _viewModel.Omega.Remove(currentIndex, count);
                _viewModel.Omega = _viewModel.Omega.Insert(currentIndex + 1, "#");
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("ifLE"))
            {
                // le logic here
                var stateNumber = _viewModel.Diagnostics.CurrentState.Module.Split('-')[1];
                var currentIndex = _viewModel.Diagnostics.OmegaIndex;
                var count = 0;
                var operand1 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand1 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }

                var operand2 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand2 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }


                // ifLE
                var isLessthanOrEqual = int.Parse(operand1) <= int.Parse(operand2);
                if (isLessthanOrEqual)
                {
                    stateCounter = int.Parse(stateNumber);
                    overrideCounter = true;
                }
                _viewModel.Omega = _viewModel.Omega.Remove(currentIndex, count);
                _viewModel.Omega = _viewModel.Omega.Insert(currentIndex + 1, "#");
                _viewModel.Diagnostics.OmegaIndex = currentIndex;
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("ifEQ"))
            {
                var stateNumber = _viewModel.Diagnostics.CurrentState.Module.Split('-')[1];
                // ifEQ logic here
                var currentIndex = _viewModel.Diagnostics.OmegaIndex;
                var count = 0;
                var operand1 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand1 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }

                var operand2 = "";
                for (int j = 0; j < _viewModel.Omega.Length;)
                {
                    _viewModel.Diagnostics.OmegaIndex++;
                    count++;
                    if (_viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString() == "#")
                    {
                        j++;
                    }
                    else
                    {
                        operand2 += _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();
                    }
                    if (1 == j)
                    {
                        break;
                    }
                }


                // ifEQ
                var isEqual = int.Parse(operand1) == int.Parse(operand2);
                if (isEqual)
                {
                    stateCounter = int.Parse(stateNumber);
                    overrideCounter = true;
                }
                _viewModel.Omega = _viewModel.Omega.Remove(currentIndex, count);
                _viewModel.Omega = _viewModel.Omega.Insert(currentIndex + 1, "#");
                _viewModel.Diagnostics.OmegaIndex = currentIndex;

            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("goto"))
            {
                // goto logic here
                var stateNumber = _viewModel.Diagnostics.CurrentState.Module.Split('-')[1];
                stateCounter = int.Parse(stateNumber);
                overrideCounter = true;
            }
            else if (_viewModel.Diagnostics.CurrentState.Module.Contains("halt"))
            {
                MessageBox.Show("The machine has reached a halt state!");
            }
            _viewModel.Diagnostics.CurrentSymbol = _viewModel.Omega[_viewModel.Diagnostics.OmegaIndex].ToString();

            // for cases where you jump to a state
            if (!overrideCounter)
            {
                stateCounter++;
            }
            State nextState = _viewModel.States.Where(s => s.StateName == stateCounter.ToString()).FirstOrDefault();

            _viewModel.Diagnostics.CurrentState = nextState;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _viewModel.Playing = false;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Rebind();
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            _viewModel.Diagnostics.OmegaIndex = 0;
            _viewModel.Diagnostics.CurrentSymbol = !string.IsNullOrEmpty(_viewModel.Omega) ? _viewModel.Omega[0].ToString() : "";
            _viewModel.Diagnostics.CurrentState = null;
            _viewModel.Diagnostics.ProcessedSymbols = "";
            _viewModel.InitialState = _viewModel.InitialState;
            stateCounter = 1;
            SetInitialState();
            UpdateCurrentStateLabel();
            UpdateProcessedSymbolLabel("");
            HighlightCurrentStateInDatagrid();
            //UpdateNextPossibleStates();
        }

        private void txtInitialState_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetInitialState();
            HighlightCurrentStateInDatagrid();
            txtInitialState.Focus();
        }
    }
}
