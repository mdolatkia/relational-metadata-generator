namespace MyProject
{
    partial class frmRuleOnValue
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgRuleOnValues = new Telerik.WinControls.UI.RadGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdateRuleOnValue = new System.Windows.Forms.Button();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.pageRuleOnColumns = new Telerik.WinControls.UI.RadPageViewPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnUpdateRuleOnValue_Columns = new System.Windows.Forms.Button();
            this.dtgRuleOnValue_Columns = new Telerik.WinControls.UI.RadGridView();
            this.pageRuleOnRelationships = new Telerik.WinControls.UI.RadPageViewPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnUpdateRuleOnValue_Relationships = new System.Windows.Forms.Button();
            this.dtgRuleOnValue_Relationships = new Telerik.WinControls.UI.RadGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValues.MasterTemplate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.pageRuleOnColumns.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValue_Columns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValue_Columns.MasterTemplate)).BeginInit();
            this.pageRuleOnRelationships.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValue_Relationships)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValue_Relationships.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgRuleOnValues);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 537);
            this.panel1.TabIndex = 0;
            // 
            // dtgRuleOnValues
            // 
            this.dtgRuleOnValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgRuleOnValues.Location = new System.Drawing.Point(0, 42);
            // 
            // 
            // 
            this.dtgRuleOnValues.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 75;
            gridViewTextBoxColumn2.FieldName = "ColumnID";
            gridViewTextBoxColumn2.HeaderText = "ColumnID";
            gridViewTextBoxColumn2.Name = "column3";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 75;
            gridViewTextBoxColumn3.FieldName = "Value";
            gridViewTextBoxColumn3.HeaderText = "Value";
            gridViewTextBoxColumn3.Name = "column2";
            gridViewTextBoxColumn3.Width = 75;
            this.dtgRuleOnValues.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.dtgRuleOnValues.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dtgRuleOnValues.Name = "dtgRuleOnValues";
            this.dtgRuleOnValues.ShowGroupPanel = false;
            this.dtgRuleOnValues.Size = new System.Drawing.Size(288, 495);
            this.dtgRuleOnValues.TabIndex = 9;
            this.dtgRuleOnValues.Text = "radGridView7";
            this.dtgRuleOnValues.SelectionChanged += new System.EventHandler(this.dtgRuleOnValues_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdateRuleOnValue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 42);
            this.panel2.TabIndex = 0;
            // 
            // btnUpdateRuleOnValue
            // 
            this.btnUpdateRuleOnValue.Location = new System.Drawing.Point(3, 12);
            this.btnUpdateRuleOnValue.Name = "btnUpdateRuleOnValue";
            this.btnUpdateRuleOnValue.Size = new System.Drawing.Size(118, 23);
            this.btnUpdateRuleOnValue.TabIndex = 3;
            this.btnUpdateRuleOnValue.Text = "Update";
            this.btnUpdateRuleOnValue.UseVisualStyleBackColor = true;
            this.btnUpdateRuleOnValue.Click += new System.EventHandler(this.btnUpdateRuleOnValue_Click);
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.pageRuleOnColumns);
            this.radPageView1.Controls.Add(this.pageRuleOnRelationships);
            this.radPageView1.DefaultPage = this.pageRuleOnColumns;
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(288, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.pageRuleOnColumns;
            this.radPageView1.Size = new System.Drawing.Size(558, 537);
            this.radPageView1.TabIndex = 1;
            this.radPageView1.Text = "radPageView1";
            // 
            // pageRuleOnColumns
            // 
            this.pageRuleOnColumns.Controls.Add(this.panel3);
            this.pageRuleOnColumns.Controls.Add(this.dtgRuleOnValue_Columns);
            this.pageRuleOnColumns.Enabled = false;
            this.pageRuleOnColumns.ItemSize = new System.Drawing.SizeF(129F, 28F);
            this.pageRuleOnColumns.Location = new System.Drawing.Point(10, 37);
            this.pageRuleOnColumns.Name = "pageRuleOnColumns";
            this.pageRuleOnColumns.Size = new System.Drawing.Size(537, 489);
            this.pageRuleOnColumns.Text = "RuleOnValue_Columns";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnUpdateRuleOnValue_Columns);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(537, 32);
            this.panel3.TabIndex = 11;
            // 
            // btnUpdateRuleOnValue_Columns
            // 
            this.btnUpdateRuleOnValue_Columns.Location = new System.Drawing.Point(3, 4);
            this.btnUpdateRuleOnValue_Columns.Name = "btnUpdateRuleOnValue_Columns";
            this.btnUpdateRuleOnValue_Columns.Size = new System.Drawing.Size(115, 23);
            this.btnUpdateRuleOnValue_Columns.TabIndex = 3;
            this.btnUpdateRuleOnValue_Columns.Text = "Update";
            this.btnUpdateRuleOnValue_Columns.UseVisualStyleBackColor = true;
            this.btnUpdateRuleOnValue_Columns.Click += new System.EventHandler(this.btnUpdateRuleOnValue_Columns_Click);
            // 
            // dtgRuleOnValue_Columns
            // 
            this.dtgRuleOnValue_Columns.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            gridViewComboBoxColumn1.FieldName = "ColumnID";
            gridViewComboBoxColumn1.HeaderText = "Column";
            gridViewComboBoxColumn1.Name = "colColumns";
            gridViewComboBoxColumn1.Width = 200;
            gridViewTextBoxColumn4.FieldName = "ValidValue";
            gridViewTextBoxColumn4.HeaderText = "Valid Value";
            gridViewTextBoxColumn4.Name = "column1";
            gridViewTextBoxColumn4.Width = 200;
            this.dtgRuleOnValue_Columns.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewComboBoxColumn1,
            gridViewTextBoxColumn4});
            this.dtgRuleOnValue_Columns.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dtgRuleOnValue_Columns.Name = "dtgRuleOnValue_Columns";
            this.dtgRuleOnValue_Columns.ShowGroupPanel = false;
            this.dtgRuleOnValue_Columns.Size = new System.Drawing.Size(537, 456);
            this.dtgRuleOnValue_Columns.TabIndex = 10;
            this.dtgRuleOnValue_Columns.Text = "radGridView7";
            // 
            // pageRuleOnRelationships
            // 
            this.pageRuleOnRelationships.Controls.Add(this.panel4);
            this.pageRuleOnRelationships.Controls.Add(this.dtgRuleOnValue_Relationships);
            this.pageRuleOnRelationships.Enabled = false;
            this.pageRuleOnRelationships.ItemSize = new System.Drawing.SizeF(152F, 28F);
            this.pageRuleOnRelationships.Location = new System.Drawing.Point(10, 37);
            this.pageRuleOnRelationships.Name = "pageRuleOnRelationships";
            this.pageRuleOnRelationships.Size = new System.Drawing.Size(537, 489);
            this.pageRuleOnRelationships.Text = "RuleOnValue_Relationships";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnUpdateRuleOnValue_Relationships);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(537, 32);
            this.panel4.TabIndex = 13;
            // 
            // btnUpdateRuleOnValue_Relationships
            // 
            this.btnUpdateRuleOnValue_Relationships.Location = new System.Drawing.Point(3, 4);
            this.btnUpdateRuleOnValue_Relationships.Name = "btnUpdateRuleOnValue_Relationships";
            this.btnUpdateRuleOnValue_Relationships.Size = new System.Drawing.Size(115, 23);
            this.btnUpdateRuleOnValue_Relationships.TabIndex = 3;
            this.btnUpdateRuleOnValue_Relationships.Text = "Update";
            this.btnUpdateRuleOnValue_Relationships.UseVisualStyleBackColor = true;
            this.btnUpdateRuleOnValue_Relationships.Click += new System.EventHandler(this.btnUpdateRuleOnValue_Relationships_Click);
            // 
            // dtgRuleOnValue_Relationships
            // 
            this.dtgRuleOnValue_Relationships.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            gridViewComboBoxColumn2.FieldName = "RelationshipID";
            gridViewComboBoxColumn2.HeaderText = "Relationship";
            gridViewComboBoxColumn2.Name = "colRelationship";
            gridViewComboBoxColumn2.Width = 300;
            gridViewCheckBoxColumn1.FieldName = "Enabled";
            gridViewCheckBoxColumn1.HeaderText = "Enabled";
            gridViewCheckBoxColumn1.Name = "column1";
            this.dtgRuleOnValue_Relationships.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewComboBoxColumn2,
            gridViewCheckBoxColumn1});
            this.dtgRuleOnValue_Relationships.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.dtgRuleOnValue_Relationships.Name = "dtgRuleOnValue_Relationships";
            this.dtgRuleOnValue_Relationships.ShowGroupPanel = false;
            this.dtgRuleOnValue_Relationships.Size = new System.Drawing.Size(537, 456);
            this.dtgRuleOnValue_Relationships.TabIndex = 12;
            this.dtgRuleOnValue_Relationships.Text = "radGridView7";
            // 
            // frmRuleOnValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 537);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmRuleOnValue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rule On Value";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValues.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValues)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.pageRuleOnColumns.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValue_Columns.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValue_Columns)).EndInit();
            this.pageRuleOnRelationships.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValue_Relationships.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRuleOnValue_Relationships)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadGridView dtgRuleOnValues;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage pageRuleOnColumns;
        private Telerik.WinControls.UI.RadGridView dtgRuleOnValue_Columns;
        private Telerik.WinControls.UI.RadPageViewPage pageRuleOnRelationships;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnUpdateRuleOnValue_Columns;
        private System.Windows.Forms.Button btnUpdateRuleOnValue;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnUpdateRuleOnValue_Relationships;
        private Telerik.WinControls.UI.RadGridView dtgRuleOnValue_Relationships;
    }
}