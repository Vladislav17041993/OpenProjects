using LoadApiUiRunner.DataStorage;
using LoadApiUiRunner.DataStorage.Models;
using System.Diagnostics;

namespace LoadApiUiRunner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void LoadTestsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedNodeName = e.Node.Name;

            if (ScenariosDictionary.ContainsKey(selectedNodeName))
            {
                var scenarioData = ScenariosDictionary.GetScenarioSettingsByName(selectedNodeName);

                RpsLabel.Visible = true;
                RpsTextBox.Visible = true;
                RpsTextBox.Text = scenarioData.Rps.ToString();
                DuringLabel.Visible = true;
                DuringTextBox.Visible = true;
                DuringTextBox.Text = scenarioData.During.ToString();
                WithWarmUpCheckBox.Visible = true;
                WithWarmUpCheckBox.Checked = scenarioData.WithWarmUp;
                WarmUpDuringTextBox.Text = scenarioData.WarmUpDuring.ToString();
                WithWarmUpCheckBox_CheckedChanged(sender, e);
            }
            else
            {
                RpsLabel.Visible = false;
                RpsTextBox.Visible = false;
                DuringLabel.Visible = false;
                DuringTextBox.Visible = false;
                WithWarmUpCheckBox.Visible = false;
                WarmUpDuringTextBox.Visible = false;
                WarmUpDuringLabel.Visible = false;
            }
        }

        private void LoadTestTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var selectedNodeName = e.Node.Name;

            if (e.Node.Checked)
            {
                if (ScenariosDictionary.ContainsKey(selectedNodeName))
                {
                    var scenarioData = new ScenarioModel
                    {
                        Rps = short.Parse(RpsTextBox.Text),
                        During = short.Parse(DuringTextBox.Text),
                        WithWarmUp = WithWarmUpCheckBox.Checked,
                        WarmUpDuring = short.Parse(WarmUpDuringTextBox.Text),
                        ShouldBeStarted = true,
                    };

                    ScenariosDictionary.SetScenarioSettingsByName(selectedNodeName, scenarioData);

                    ScenarioListTextBox.Text = ScenariosDictionary.PrintScenariosToRun();
                }
            }

            if (!e.Node.Checked)
            {
                if (ScenariosDictionary.ContainsKey(selectedNodeName))
                {
                    var scenarioData = new ScenarioModel
                    {
                        Rps = short.Parse(RpsTextBox.Text),
                        During = short.Parse(DuringTextBox.Text),
                        WithWarmUp = WithWarmUpCheckBox.Checked,
                        WarmUpDuring = short.Parse(WarmUpDuringTextBox.Text),
                        ShouldBeStarted = false,
                    };

                    ScenariosDictionary.SetScenarioSettingsByName(selectedNodeName, scenarioData);

                    ScenarioListTextBox.Text = ScenariosDictionary.PrintScenariosToRun();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void WithWarmUpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (WithWarmUpCheckBox.Checked)
            {
                WarmUpDuringLabel.Visible = true;
                WarmUpDuringTextBox.Visible = true;
                return;
            }

            WarmUpDuringLabel.Visible = false;
            WarmUpDuringTextBox.Visible = false;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = false;

            var scenarios = ScenariosDictionary.GetScenariosToRun();
            foreach (var scenario in scenarios)
            {
                try
                {
                    using Process myProcess = new()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            Arguments = $"{scenario.Key} {scenario.Value.Rps} {scenario.Value.During} {scenario.Value.WithWarmUp} {scenario.Value.WarmUpDuring}",
                            FileName = Path.Combine(Directory.GetCurrentDirectory(), "LoadApiTestsConsole\\LoadApiTest.exe")
                        }
                    };

                    myProcess.Start();
                    myProcess.WaitForExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            StartButton.Enabled = true;
        }

        private TreeNode SearchNode(string SearchText, TreeNode StartNode)
        {
            TreeNode node = null;
            while (StartNode != null)
            {
                if (StartNode.Text.ToLower().Contains(SearchText.ToLower()))
                {
                    node = StartNode;
                    break;
                };
                if (StartNode.Nodes.Count != 0)
                {
                    node = SearchNode(SearchText, StartNode.Nodes[0]);//Recursive Search
                    if (node != null)
                    {
                        break;
                    };
                };
                StartNode = StartNode.NextNode;
            };
            return node;
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            this.SearchTextBox.Text = "";
        }

        
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            


            string SearchText = this.SearchTextBox.Text;
            if (SearchText == "")
            {
                return;
            };
            TreeNode SelectedNode = SearchNode(SearchText, LoadTestsTreeView.Nodes[0]);
            if (SelectedNode != null)
            {
                this.LoadTestsTreeView.SelectedNode = SelectedNode;
                this.LoadTestsTreeView.SelectedNode.Expand();
                this.LoadTestsTreeView.Select();
            };
        }
    }
}
