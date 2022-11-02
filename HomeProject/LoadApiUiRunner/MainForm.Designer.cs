namespace LoadApiUiRunner
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("PetRequests");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("PostOrderScenario");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("GetOrderScenario");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("StoreRequests", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("UserRequests");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("PetStore3Api", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode5});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BaseTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TestSettings = new System.Windows.Forms.GroupBox();
            this.WarmUpDuringTextBox = new System.Windows.Forms.TextBox();
            this.WarmUpDuringLabel = new System.Windows.Forms.Label();
            this.WithWarmUpCheckBox = new System.Windows.Forms.CheckBox();
            this.DuringTextBox = new System.Windows.Forms.TextBox();
            this.DuringLabel = new System.Windows.Forms.Label();
            this.RpsLabel = new System.Windows.Forms.Label();
            this.RpsTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StartButton = new System.Windows.Forms.Button();
            this.ScenarioList = new System.Windows.Forms.GroupBox();
            this.ScenarioListTextBox = new System.Windows.Forms.TextBox();
            this.LoadTestListGroupbox = new System.Windows.Forms.GroupBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.LoadTestsTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.BaseTableLayout.SuspendLayout();
            this.TestSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ScenarioList.SuspendLayout();
            this.LoadTestListGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.menuToolStripMenuItem.Text = "Help";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // BaseTableLayout
            // 
            this.BaseTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BaseTableLayout.ColumnCount = 3;
            this.BaseTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BaseTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BaseTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BaseTableLayout.Controls.Add(this.TestSettings, 1, 0);
            this.BaseTableLayout.Controls.Add(this.tableLayoutPanel1, 2, 0);
            this.BaseTableLayout.Controls.Add(this.LoadTestListGroupbox, 0, 0);
            this.BaseTableLayout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BaseTableLayout.Location = new System.Drawing.Point(12, 27);
            this.BaseTableLayout.Name = "BaseTableLayout";
            this.BaseTableLayout.RowCount = 1;
            this.BaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.BaseTableLayout.Size = new System.Drawing.Size(868, 392);
            this.BaseTableLayout.TabIndex = 1;
            // 
            // TestSettings
            // 
            this.TestSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestSettings.Controls.Add(this.WarmUpDuringTextBox);
            this.TestSettings.Controls.Add(this.WarmUpDuringLabel);
            this.TestSettings.Controls.Add(this.WithWarmUpCheckBox);
            this.TestSettings.Controls.Add(this.DuringTextBox);
            this.TestSettings.Controls.Add(this.DuringLabel);
            this.TestSettings.Controls.Add(this.RpsLabel);
            this.TestSettings.Controls.Add(this.RpsTextBox);
            this.TestSettings.Location = new System.Drawing.Point(292, 3);
            this.TestSettings.Name = "TestSettings";
            this.TestSettings.Size = new System.Drawing.Size(283, 386);
            this.TestSettings.TabIndex = 1;
            this.TestSettings.TabStop = false;
            this.TestSettings.Text = "TestSettings";
            // 
            // WarmUpDuringTextBox
            // 
            this.WarmUpDuringTextBox.Location = new System.Drawing.Point(149, 140);
            this.WarmUpDuringTextBox.Name = "WarmUpDuringTextBox";
            this.WarmUpDuringTextBox.Size = new System.Drawing.Size(30, 23);
            this.WarmUpDuringTextBox.TabIndex = 7;
            this.WarmUpDuringTextBox.Text = "1";
            this.WarmUpDuringTextBox.Visible = false;
            // 
            // WarmUpDuringLabel
            // 
            this.WarmUpDuringLabel.AutoSize = true;
            this.WarmUpDuringLabel.Location = new System.Drawing.Point(22, 143);
            this.WarmUpDuringLabel.Name = "WarmUpDuringLabel";
            this.WarmUpDuringLabel.Size = new System.Drawing.Size(121, 15);
            this.WarmUpDuringLabel.TabIndex = 6;
            this.WarmUpDuringLabel.Text = "WarmUp during(min)";
            this.WarmUpDuringLabel.Visible = false;
            this.WarmUpDuringLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // WithWarmUpCheckBox
            // 
            this.WithWarmUpCheckBox.AutoSize = true;
            this.WithWarmUpCheckBox.Location = new System.Drawing.Point(6, 110);
            this.WithWarmUpCheckBox.Name = "WithWarmUpCheckBox";
            this.WithWarmUpCheckBox.Size = new System.Drawing.Size(98, 19);
            this.WithWarmUpCheckBox.TabIndex = 5;
            this.WithWarmUpCheckBox.Text = "WithWarmUp";
            this.WithWarmUpCheckBox.UseVisualStyleBackColor = true;
            this.WithWarmUpCheckBox.Visible = false;
            this.WithWarmUpCheckBox.CheckedChanged += new System.EventHandler(this.WithWarmUpCheckBox_CheckedChanged);
            // 
            // DuringTextBox
            // 
            this.DuringTextBox.Location = new System.Drawing.Point(84, 68);
            this.DuringTextBox.Name = "DuringTextBox";
            this.DuringTextBox.Size = new System.Drawing.Size(30, 23);
            this.DuringTextBox.TabIndex = 4;
            this.DuringTextBox.Text = "1";
            this.DuringTextBox.Visible = false;
            // 
            // DuringLabel
            // 
            this.DuringLabel.AutoSize = true;
            this.DuringLabel.Location = new System.Drawing.Point(6, 71);
            this.DuringLabel.Name = "DuringLabel";
            this.DuringLabel.Size = new System.Drawing.Size(75, 15);
            this.DuringLabel.TabIndex = 3;
            this.DuringLabel.Text = "During(min):";
            this.DuringLabel.Visible = false;
            // 
            // RpsLabel
            // 
            this.RpsLabel.AutoSize = true;
            this.RpsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RpsLabel.Location = new System.Drawing.Point(6, 28);
            this.RpsLabel.Name = "RpsLabel";
            this.RpsLabel.Size = new System.Drawing.Size(30, 15);
            this.RpsLabel.TabIndex = 2;
            this.RpsLabel.Text = "RPS:";
            this.RpsLabel.Visible = false;
            // 
            // RpsTextBox
            // 
            this.RpsTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RpsTextBox.Location = new System.Drawing.Point(84, 25);
            this.RpsTextBox.Name = "RpsTextBox";
            this.RpsTextBox.Size = new System.Drawing.Size(30, 23);
            this.RpsTextBox.TabIndex = 1;
            this.RpsTextBox.Text = "5";
            this.RpsTextBox.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.StartButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ScenarioList, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(581, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.44086F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.55914F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 386);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Location = new System.Drawing.Point(171, 346);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(110, 37);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ScenarioList
            // 
            this.ScenarioList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScenarioList.Controls.Add(this.ScenarioListTextBox);
            this.ScenarioList.Location = new System.Drawing.Point(3, 3);
            this.ScenarioList.Name = "ScenarioList";
            this.ScenarioList.Size = new System.Drawing.Size(278, 335);
            this.ScenarioList.TabIndex = 1;
            this.ScenarioList.TabStop = false;
            this.ScenarioList.Text = "ScenarioList";
            // 
            // ScenarioListTextBox
            // 
            this.ScenarioListTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScenarioListTextBox.Location = new System.Drawing.Point(6, 19);
            this.ScenarioListTextBox.Multiline = true;
            this.ScenarioListTextBox.Name = "ScenarioListTextBox";
            this.ScenarioListTextBox.ReadOnly = true;
            this.ScenarioListTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ScenarioListTextBox.Size = new System.Drawing.Size(266, 310);
            this.ScenarioListTextBox.TabIndex = 0;
            // 
            // LoadTestListGroupbox
            // 
            this.LoadTestListGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadTestListGroupbox.Controls.Add(this.SearchTextBox);
            this.LoadTestListGroupbox.Controls.Add(this.LoadTestsTreeView);
            this.LoadTestListGroupbox.Location = new System.Drawing.Point(3, 3);
            this.LoadTestListGroupbox.Name = "LoadTestListGroupbox";
            this.LoadTestListGroupbox.Size = new System.Drawing.Size(283, 386);
            this.LoadTestListGroupbox.TabIndex = 0;
            this.LoadTestListGroupbox.TabStop = false;
            this.LoadTestListGroupbox.Text = "LoadTestsList";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Location = new System.Drawing.Point(6, 20);
            this.SearchTextBox.MaxLength = 50;
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(271, 23);
            this.SearchTextBox.TabIndex = 1;
            this.SearchTextBox.Text = "Search";
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            this.SearchTextBox.Click += new System.EventHandler(this.SearchTextBox_Click);
            // 
            // LoadTestsTreeView
            // 
            this.LoadTestsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadTestsTreeView.BackColor = System.Drawing.SystemColors.Control;
            this.LoadTestsTreeView.CheckBoxes = true;
            this.LoadTestsTreeView.Location = new System.Drawing.Point(6, 48);
            this.LoadTestsTreeView.Name = "LoadTestsTreeView";
            treeNode1.Name = "PetRequests";
            treeNode1.Text = "PetRequests";
            treeNode2.Name = "PostOrderScenario";
            treeNode2.Text = "PostOrderScenario";
            treeNode3.Name = "GetOrderScenario";
            treeNode3.Text = "GetOrderScenario";
            treeNode4.Name = "StoreRequests";
            treeNode4.Text = "StoreRequests";
            treeNode5.Name = "UserRequests";
            treeNode5.Text = "UserRequests";
            treeNode6.Name = "PetStore3Api";
            treeNode6.Text = "PetStore3Api";
            this.LoadTestsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.LoadTestsTreeView.Size = new System.Drawing.Size(271, 331);
            this.LoadTestsTreeView.TabIndex = 0;
            this.LoadTestsTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.LoadTestTreeView_AfterCheck);
            this.LoadTestsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.LoadTestsTreeView_AfterSelect);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 431);
            this.Controls.Add(this.BaseTableLayout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(908, 470);
            this.Name = "MainForm";
            this.Text = "LoadTestRunner";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.BaseTableLayout.ResumeLayout(false);
            this.TestSettings.ResumeLayout(false);
            this.TestSettings.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ScenarioList.ResumeLayout(false);
            this.ScenarioList.PerformLayout();
            this.LoadTestListGroupbox.ResumeLayout(false);
            this.LoadTestListGroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private TableLayoutPanel BaseTableLayout;
        private GroupBox LoadTestListGroupbox;
        private TreeView LoadTestsTreeView;
        private GroupBox TestSettings;
        private TableLayoutPanel tableLayoutPanel1;
        private Button StartButton;
        private Label RpsLabel;
        private TextBox RpsTextBox;
        private CheckBox WithWarmUpCheckBox;
        private TextBox DuringTextBox;
        private Label DuringLabel;
        private Label WarmUpDuringLabel;
        private TextBox WarmUpDuringTextBox;
        private GroupBox ScenarioList;
        private TextBox ScenarioListTextBox;
        private TextBox SearchTextBox;
    }
}