using DataAccess;
using MyDataManagerBusiness;
using MyRuleEngine;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRules.TableRules.TableDrivedEntity_Relationships.Action
{
    public class Action1 : IAction
    {
        public ActionResultEnum Execute(object[] objects)
        {
            //var catalogName = ObjectExtractor.Extract<string>(objects);
            var context = ObjectExtractor.Extract<MyProjectEntities>(objects);
            //if (string.IsNullOrEmpty(catalogName))
            //{
            //    throw new Exception("Database Name is not defined!");
            //}
            //var listEntity = context.TableDrivedEntity.Where(x => x.TableDrivedEntity.Table.Catalog == catalogName);

            //int number = 0;
            ////List<EntityInfo> listEntitInfo = new List<EntityInfo>();
            //foreach (var entity in listEntity.Where(x => x.TableDrivedEntity != null))
            //{
            //    number++;
            //    if (ActionEvent != null)
            //        ActionEvent(this, new ActionInfoArg() { Title = entity.Name, TotalEventsCount = listEntity.Count(), EventsNumber = number });
            var entity = ObjectExtractor.Extract<TableDrivedEntity>(objects);


            var entityInfo = DataHelper.GetEntityRelationshipsInfo(entity, true, false);


            var relations = entityInfo.RelationInfos;
            Tuple<ISARelationship, TableDrivedEntity, List<TableDrivedEntity>> iSARelationship = null;
            Tuple<UnionRelationshipType, TableDrivedEntity, List<TableDrivedEntity>, UnionKeyType> unionRelationship = null;
            foreach (var item in relations)
            {
               
           
                bool isaCondition = false;
                if ( (item.FKRelatesOnPrimaryKey))
                {

                    isaCondition = true;
                }

                //bool unionConditionSubUnionHoldsKey = false;
                //bool unionConditionUnionHoldsKey = false;
                //if (item.OtherSideEntity.TableDrivedEntity3.Contains(entity))
                //    unionConditionSubUnionHoldsKey = true;
                //if (entity.TableDrivedEntity3.Contains(item.OtherSideEntity))
                //    unionConditionUnionHoldsKey = true;

                //if ((unionConditionUnionHoldsKey && unionConditionSubUnionHoldsKey)
                //    || (unionConditionSubUnionHoldsKey && isaCondition)
                //    || (isaCondition && unionConditionUnionHoldsKey))
                //    throw new Exception("ISA relationship or Union relationship at same time!");

                if (isaCondition )//|| unionConditionSubUnionHoldsKey || unionConditionUnionHoldsKey)
                    if (item.RelationType == RelationType.ManyDataItems && item.FKHasData)
                        throw new Exception("ISA or Union relationship with multiple data!");


                if (isaCondition)
                {
                    Relationship reverseRelationship = DataHelper.GetReverseRelationship(context, item.Relationship);
                    if (item.Relationship.RelationshipType == null)
                    {
                        item.Relationship.RelationshipType = new RelationshipType();
                        reverseRelationship.RelationshipType = new RelationshipType();
                    }
                    else
                    {
                        DataHelper.ClearRelationshipType(item.Relationship.RelationshipType);
                        DataHelper.ClearRelationshipType(reverseRelationship.RelationshipType);
                    }
                    item.Relationship.Enabled = true;
                    reverseRelationship.Enabled = true;
                    if (iSARelationship == null)
                    {
                        iSARelationship = new Tuple<ISARelationship, TableDrivedEntity, List<TableDrivedEntity>>(new ISARelationship(), entityInfo.TableDrivedEntity, new List<TableDrivedEntity>());

                    }
                    iSARelationship.Item3.Add(item.OtherSideEntity);
                    item.Relationship.RelationshipType.SuperToSubRelationshipType = new SuperToSubRelationshipType();
                    item.Relationship.RelationshipType.IsOtherSideCreatable = true;
                    //item.Item1.RelationshipType.SuperToSubRelationshipType.IsOtherSideDirectlyCreatable = true;
                    item.Relationship.RelationshipType.SuperToSubRelationshipType.ISARelationship = iSARelationship.Item1;


                    reverseRelationship.RelationshipType.SubToSuperRelationshipType = new SubToSuperRelationshipType();
                    reverseRelationship.RelationshipType.IsOtherSideCreatable = true;
                    //reverseRelationship.RelationshipType.SubToSuperRelationshipType.IsOtherSideDirectlyCreatable = true;
                    reverseRelationship.RelationshipType.SubToSuperRelationshipType.ISARelationship = iSARelationship.Item1;

                    //if (!item.OtherSideEntity.TableDrivedEntity2.Contains(entityInfo.TableDrivedEntity))
                    //{
                    //    item.OtherSideEntity.TableDrivedEntity2.Add(entityInfo.TableDrivedEntity);
                    //}
                   

                }//subunion holds key
                //else if (unionConditionSubUnionHoldsKey)
                //{
                //    Relationship reverseRelationship = DataHelper.GetReverseRelationship(context, item.Relationship);
                //    if (item.Relationship.RelationshipType == null)
                //    {
                //        item.Relationship.RelationshipType = new RelationshipType();
                //        reverseRelationship.RelationshipType = new RelationshipType();
                //    }
                //    else
                //    {
                //        DataHelper.ClearRelationshipType(item.Relationship.RelationshipType);
                //        DataHelper.ClearRelationshipType(reverseRelationship.RelationshipType);
                //    }
                //    item.Relationship.Enabled = true;
                //    reverseRelationship.Enabled = true;
                //    if (unionRelationship == null)
                //    {
                       
                //        unionRelationship = Tuple.Create<UnionRelationshipType, TableDrivedEntity, List<TableDrivedEntity>, UnionKeyType>(new UnionRelationshipType(), entityInfo.TableDrivedEntity, new List<TableDrivedEntity>(), UnionKeyType.SubUnionHoldsKeys);
                //    }
                //    unionRelationship.Item3.Add(item.OtherSideEntity);
                //    item.Relationship.RelationshipType.UnionToSubUnionRelationshipType = new UnionToSubUnionRelationshipType();
                //    item.Relationship.RelationshipType.IsOtherSideCreatable = true;
                //    //item.Item1.RelationshipType.UnionToSubUnionRelationshipType.IsOtherSideDirectlyCreatable = true;
                //    item.Relationship.RelationshipType.UnionToSubUnionRelationshipType.UnionRelationshipType = unionRelationship.Item1;
                //    item.Relationship.RelationshipType.UnionToSubUnionRelationshipType.UnionRelationshipType.UnionHoldsKeys = false;

                //    reverseRelationship.RelationshipType.SubUnionToUnionRelationshipType = new SubUnionToUnionRelationshipType();
                //    reverseRelationship.RelationshipType.IsOtherSideCreatable = true;
                //    //reverseRelationship.RelationshipType.SubUnionToUnionRelationshipType.IsOtherSideDirectlyCreatable = true;
                //    reverseRelationship.RelationshipType.SubUnionToUnionRelationshipType.UnionRelationshipType = unionRelationship.Item1;


                //}
                ////entity.TableDrivedEntity.TableDrivedEntity3 =unions
                //// item.OtherSideEntity.TableDrivedEntity is union
                ////union holds key
                //else if (unionConditionUnionHoldsKey)
                //{
                //    if (!entity.Relationship.Any(x => x.TableDrivedEntity.ID == item.OtherSideEntity.ID && x.RelationshipType != null && context.Entry(x.RelationshipType).State == EntityState.Added && x.RelationshipType.UnionToSubUnionRelationshipType != null))
                //    {
                //        var relationShips = context.Relationship.Where(x => x.TableDrivedEntity.ID == item.OtherSideEntity.ID && x.TableDrivedEntity1.TableDrivedEntity3.Contains(x.TableDrivedEntity));
                //        foreach (var relationship in relationShips)
                //        {

                //            Relationship reverseRelationship = DataHelper.GetReverseRelationship(context, relationship);
                //            if (relationship.RelationshipType == null)
                //            {
                //                relationship.RelationshipType = new RelationshipType();
                //                reverseRelationship.RelationshipType = new RelationshipType();
                //            }
                //            else
                //            {
                //                DataHelper.ClearRelationshipType(relationship.RelationshipType);
                //                DataHelper.ClearRelationshipType(reverseRelationship.RelationshipType);
                //            }
                //            relationship.Enabled = true;
                //            reverseRelationship.Enabled = true;
                //            if (unionRelationship == null)
                //            {
                //                unionRelationship = new Tuple<UnionRelationshipType, TableDrivedEntity, List<TableDrivedEntity>, UnionKeyType>(new UnionRelationshipType(), relationship.TableDrivedEntity, new List<TableDrivedEntity>(), UnionKeyType.UnionHoldsKeys);

                //            }
                //            unionRelationship.Item3.Add(relationship.TableDrivedEntity1);

                //            relationship.RelationshipType.UnionToSubUnionRelationshipType = new UnionToSubUnionRelationshipType();
                //            relationship.RelationshipType.IsOtherSideCreatable = true;
                //            //relationship.RelationshipType.UnionToSubUnionRelationshipType.IsOtherSideDirectlyCreatable = true;
                //            relationship.RelationshipType.UnionToSubUnionRelationshipType.UnionRelationshipType = unionRelationship.Item1;
                //            relationship.RelationshipType.UnionToSubUnionRelationshipType.UnionRelationshipType.UnionHoldsKeys = true;

                //            reverseRelationship.RelationshipType.SubUnionToUnionRelationshipType = new SubUnionToUnionRelationshipType();
                //            reverseRelationship.RelationshipType.IsOtherSideCreatable = true;
                //            //reverseRelationship.RelationshipType.SubUnionToUnionRelationshipType.IsOtherSideDirectlyCreatable = true;
                //            reverseRelationship.RelationshipType.SubUnionToUnionRelationshipType.UnionRelationshipType = unionRelationship.Item1;

                //        }
                //    }
                //    else
                //    {

                //    }
                //}
                else if (item.RelationType == RelationType.OneDataItems)
                {//implicit explicit
                    Relationship reverseRelationship = DataHelper.GetReverseRelationship(context, item.Relationship);
                    if (item.Relationship.RelationshipType == null)
                    {
                        item.Relationship.RelationshipType = new RelationshipType();
                        reverseRelationship.RelationshipType = new RelationshipType();
                    }
                    else
                    {
                        DataHelper.ClearRelationshipType(item.Relationship.RelationshipType);
                        DataHelper.ClearRelationshipType(reverseRelationship.RelationshipType);
                    }

                    item.Relationship.Enabled = true;
                    reverseRelationship.Enabled = true;


                    item.Relationship.RelationshipType.ImplicitOneToOneRelationshipType = new ImplicitOneToOneRelationshipType();
                    item.Relationship.RelationshipType.IsOtherSideCreatable = true;
                    //item.Item1.RelationshipType.ImplicitOneToOneRelationshipType.IsOtherSideDirectlyCreatable = true;
                    item.Relationship.RelationshipType.IsOtherSideMandatory = item.AllPrimarySideHasFkSideData;

                    reverseRelationship.RelationshipType.ExplicitOneToOneRelationshipType = new ExplicitOneToOneRelationshipType();
                    reverseRelationship.RelationshipType.IsOtherSideCreatable = true;
                    //reverseRelationship.RelationshipType.ExplicitOneToOneRelationshipType.IsOtherSideDirectlyCreatable = true;
                    reverseRelationship.RelationshipType.IsOtherSideMandatory = item.FKColumnIsMandatory;

                }
                else if (item.RelationType == RelationType.ManyDataItems)
                {
                    Relationship reverseRelationship = DataHelper.GetReverseRelationship(context, item.Relationship);
                    if (item.Relationship.RelationshipType == null)
                    {
                        item.Relationship.RelationshipType = new RelationshipType();
                        reverseRelationship.RelationshipType = new RelationshipType();
                    }
                    else
                    {
                        DataHelper.ClearRelationshipType(item.Relationship.RelationshipType);
                        DataHelper.ClearRelationshipType(reverseRelationship.RelationshipType);
                    }

                    item.Relationship.Enabled = true;
                    reverseRelationship.Enabled = true;

                    item.Relationship.RelationshipType.OneToManyRelationshipType = new OneToManyRelationshipType();
                    item.Relationship.RelationshipType.IsOtherSideMandatory = item.AllPrimarySideHasFkSideData;
                    item.Relationship.RelationshipType.IsOtherSideCreatable = true;

                    //item.Item1.RelationshipType.OneToManyRelationshipType.IsManySideDirectlyCreatable = true;

                    reverseRelationship.RelationshipType.ManyToOneRelationshipType = new ManyToOneRelationshipType();
                    reverseRelationship.RelationshipType.IsOtherSideCreatable = true;
                    //reverseRelationship.RelationshipType.ManyToOneRelationshipType.IsOneSideDirectlyCreatable = true;
                    reverseRelationship.RelationshipType.IsOtherSideMandatory = item.FKColumnIsMandatory;
                }

           
            }

            if (unionRelationship != null)
            {
                DataHelper.SetUnion_RelationshipProperties(unionRelationship);
            }
            if (iSARelationship != null)
            {
                DataHelper.SetISA_RelationshipProperties(iSARelationship);
            }

            return ActionResultEnum.Successful;
        }




        public event EventHandler<ActionInfoArg> ActionEvent;




    }

   
}
