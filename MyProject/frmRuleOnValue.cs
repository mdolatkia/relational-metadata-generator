using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace MyProject
{
    public partial class frmRuleOnValue : Form
    {
        int ColumnID { set; get; }
        public frmRuleOnValue(int columnID)
        {
            InitializeComponent();
            ColumnID = columnID;

            SetRuleOnValueGrid();


        }

        private void SetRuleOnValueGrid()
        {
            using (var projectContext = new DataAccess.MyProjectEntities())
            {
                var column = projectContext.Column.First(x => x.ID == ColumnID);
                dtgRuleOnValues.DataSource = column.RuleOnValue.ToList();

                var col = dtgRuleOnValue_Columns.Columns[0] as GridViewComboBoxColumn;
                col.DataSource = column.Table.Column.ToList();
                col.DisplayMember = "Name";
                col.ValueMember = "ID";

                var rel = dtgRuleOnValue_Relationships.Columns[0] as GridViewComboBoxColumn;

                List<Relationship> listRelationships = new List<Relationship>();
                foreach (var item in column.Table.TableDrivedEntity)
                {
                    foreach (var relationship in item.Relationship)
                        listRelationships.Add(relationship);
                    foreach (var relationship in item.Relationship1)
                        listRelationships.Add(relationship);

                }
                rel.DataSource = listRelationships;
                rel.DisplayMember = "Name";
                rel.ValueMember = "ID";
            }
        }


        private void dtgRuleOnValues_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgRuleOnValues.SelectedRows.Count > 0)
            {
                var ruleOnValue = dtgRuleOnValues.SelectedRows.First().DataBoundItem as RuleOnValue;
                if (ruleOnValue.ID == 0)
                {
                    pageRuleOnColumns.Enabled = false;
                    pageRuleOnRelationships.Enabled = false;
                }
                else
                {
                    pageRuleOnColumns.Enabled = true;
                    pageRuleOnRelationships.Enabled = true;
                }
                using (var projectContext = new DataAccess.MyProjectEntities())
                {
                    var listCol = projectContext.RuleOnValue_Column.Where(x => x.RuleOnValueID == ruleOnValue.ID);
                    dtgRuleOnValue_Columns.DataSource = listCol.ToList();

                    var listRel = projectContext.RuleOnValue_Relationship.Where(x => x.RuleOnValueID == ruleOnValue.ID);
                    dtgRuleOnValue_Relationships.DataSource = listRel.ToList();
                }

            }
            else
            {
                pageRuleOnColumns.Enabled = false;
                pageRuleOnRelationships.Enabled = false;
            }
        }

        private void btnUpdateRuleOnValue_Columns_Click(object sender, EventArgs e)
        {
            using (var projectContext = new DataAccess.MyProjectEntities())
            {
                var list = dtgRuleOnValue_Columns.DataSource as List<RuleOnValue_Column>;
                var ruleOnValue = dtgRuleOnValues.SelectedRows.First().DataBoundItem as RuleOnValue;
                projectContext.RuleOnValue_Column.RemoveRange(projectContext.RuleOnValue_Column.Where(x => x.RuleOnValueID == ruleOnValue.ID));
                foreach (var item in list)
                {
                    projectContext.RuleOnValue_Column.Add(new RuleOnValue_Column() { RuleOnValueID = ruleOnValue.ID, ColumnID = item.ColumnID, ValidValue = item.ValidValue });
                }
                projectContext.SaveChanges();

                SetRuleOnValueGrid();
            }
        }

        private void btnUpdateRuleOnValue_Click(object sender, EventArgs e)
        {

            using (var projectContext = new DataAccess.MyProjectEntities())
            {
                foreach (var item in dtgRuleOnValues.DataSource as List<RuleOnValue>)
                {
                    RuleOnValue dbItem = null;
                    if (item.ID == 0)
                    {
                        dbItem = new RuleOnValue();
                        projectContext.RuleOnValue.Add(dbItem);
                    }
                    else
                        dbItem = projectContext.RuleOnValue.First(x => x.ID == item.ID);
                    dbItem.Value = item.Value;
                    dbItem.ColumnID = ColumnID;
                    projectContext.SaveChanges();
                }
            }
            SetRuleOnValueGrid();

        }

        private void btnUpdateRuleOnValue_Relationships_Click(object sender, EventArgs e)
        {
            using (var projectContext = new DataAccess.MyProjectEntities())
            {
                var list = dtgRuleOnValue_Relationships.DataSource as List<RuleOnValue_Relationship>;
                var ruleOnValue = dtgRuleOnValues.SelectedRows.First().DataBoundItem as RuleOnValue;
                projectContext.RuleOnValue_Relationship.RemoveRange(projectContext.RuleOnValue_Relationship.Where(x => x.RuleOnValueID == ruleOnValue.ID));

                var rel = dtgRuleOnValue_Relationships.Columns[0] as GridViewComboBoxColumn;
                var allRelationships = rel.DataSource as List<Relationship>;
                List<RuleOnValue_Relationship> addList = new List<RuleOnValue_Relationship>();
                List<int> visitedIds = new List<int>();
                foreach (var item in list)
                {
                    if (!visitedIds.Contains(item.RelationshipID))
                    {
                        visitedIds.Add(item.RelationshipID);
                        var pariItem = allRelationships.First(x => x.ID == item.RelationshipID);
                        if (pariItem != null)
                        {
                            if (pariItem.RelationshipID != null)
                            {
                                visitedIds.Add(pariItem.RelationshipID.Value);
                                if (!list.Any(x => x.RelationshipID == pariItem.RelationshipID))
                                {
                                    addList.Add(new RuleOnValue_Relationship() { RelationshipID = pariItem.RelationshipID.Value, Enabled = item.Enabled });
                                }
                                else
                                    list.First(x => x.RelationshipID == pariItem.RelationshipID).Enabled = item.Enabled;
                            }
                            else
                            {
                                var revRel = allRelationships.First(x => x.RelationshipID == pariItem.ID);

                                visitedIds.Add(revRel.ID);
                                if (!list.Any(x => x.RelationshipID == revRel.ID))
                                {
                                    addList.Add(new RuleOnValue_Relationship() { RelationshipID = revRel.ID, Enabled = item.Enabled });
                                }
                                else
                                    list.First(x => x.RelationshipID == revRel.ID).Enabled = item.Enabled;
                            }
                        }
                    }
                }

                foreach (var item in addList)
                {
                    list.Add(item);
                }
                foreach (var item in list)
                {
                    projectContext.RuleOnValue_Relationship.Add(new RuleOnValue_Relationship() { RuleOnValueID = ruleOnValue.ID, RelationshipID = item.RelationshipID, Enabled = item.Enabled });
                }
                projectContext.SaveChanges();

                SetRuleOnValueGrid();
            }
        }
    }
}
