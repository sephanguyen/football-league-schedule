using Business.interfaces;
using Microsoft.Extensions.Logging;
using Model.Model;
using Model.PostParametersModels;
using Repositories.ConnectionBase;
using Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ApiConfiguration.Utilities;
using Business.Services;
using Business.Extension;
using Model.MatchPostParameter.PostParametersModels;
using System;
using Repositories.Enum;

namespace Business.implements
{
    public class FixtureBusiness : BusinessBase, IFixtureBusiness
    {
        private readonly IGeneraterFixture _generaterFixture;
        public FixtureBusiness(IDbContext dbContext,
                                ILogger<BusinessBase> logger,
                                IGeneraterFixture generaterFixture,
                                IPropertyMappingService propertyMappingService) : base(dbContext, logger, propertyMappingService)
        {
            _generaterFixture = generaterFixture ?? throw new ArgumentException("generaterFixture is null");
        }

        public async Task<IEnumerable<Match>> GenerateFixture()
        {
            var listTeam = await (DbContext.TeamRepository.FindAllAsync(x => x.Deleted != StatusDelete.Deleted));
            IList<Match> listmatch = _generaterFixture.RandomMatchs(listTeam.ToList());
            var countRecordInsert = await DbContext.MatchRepository.BulkInsertAsync(listmatch);
            if(countRecordInsert <= 0) {
                throw new Exception("Creating matchs failed on save.");
            }
            return listmatch;
        }

        // public async Task<PagedList<Player>> GetAllPlayerWithTeam(PlayerPostParametersModel playerPostParameters)
        // {
        //     IList<Player> collectionBeforePaging; 
        //     if (!string.IsNullOrEmpty(playerPostParameters.SearchQuery))
        //     {
        //         var searchQueryForWhereClause = playerPostParameters.SearchQuery.Trim().ToLowerInvariant();
        //         collectionBeforePaging = (await DbContext.PlayerRepository.FindAllAsync(
        //                                 x => x.FirstName.ToLowerInvariant().Contains(searchQueryForWhereClause) ||
        //                                     x.LastName.ToLowerInvariant().Contains(searchQueryForWhereClause)
        //                                 )).ToList();
        //     }
        //     else
        //     {
        //         collectionBeforePaging  = (await DbContext.PlayerRepository.FindAllAsync()).ToList();
        //     }
            
        //     collectionBeforePaging = collectionBeforePaging.ApplySort(playerPostParameters.OrderBy, PropertyMappingService.GetPropertyMapping<PlayerModel, Player>());

        //     return PagedList<Player>.Create(collectionBeforePaging, playerPostParameters.PageNumber, playerPostParameters.PageSize);
        // }

        public async Task<IEnumerable<Match>> GetListFixture(ListFixturePostParametersModel matchPostParameters)
        {
            return new List<Match> {
                new Match() {
                  Id = 1,
                 MatchDate = DateTime.Now,
                 Round = 1,
                 TeamHomeId = 1,
                 ScoreAway = 1,
                 ScoreHome = 1,
                 TeamHome = new Team() {
                     Id = 1,
                     Name = "Manchester United"
                 },
                 TeamAwayId = 2,
                 TeamAway = new Team() {
                     Id = 2,
                     Name = "Manchester City"
                 },
                 SeasonId = 1,
                 StadiumName = "Entihad",
                 Goals = new List<Goal>() {
                     new Goal() {
                         PlayerId = 1,
                         Players = new Player() {
                             Id = 1,
                             FirstName = "Segri",
                             LastName = "Aguero"
                         },
                         MatchId = 1,
                         TimeGoal = DateTime.Now,
                         TypeGoalId = 1,
                         TypeGoal = new TypeGoal() {
                             Id = 1,
                             Name = "A",
                             Value = 3
                         }
                         
                     }
                 }
                },
                new Match() {
                  Id = 2,
                 MatchDate = DateTime.Now,
                 Round = 1,
                 TeamHomeId = 3,
                 TeamHome = new Team() {
                     Id = 3,
                     Name = "Barcelona"
                 },
                 TeamAwayId = 4,
                 TeamAway = new Team() {
                     Id = 4,
                     Name = "Real Madrid"
                 },
                 SeasonId = 1,
                 StadiumName = "Noucamp"
                }
            };
        }

        public async Task<bool> UpdateMatch(UpdateMatchPostParametersModel updateMatchModelPostParameter)
        {
            bool updateCompleted = false;
            var matchUpdate = await DbContext.MatchRepository.FindByIdAsync(updateMatchModelPostParameter.MatchId);
            if(matchUpdate != null) {
                matchUpdate.ScoreHome = updateMatchModelPostParameter.ScoreHome;
                matchUpdate.ScoreAway = updateMatchModelPostParameter.ScoreAway;
                using (var trans = DbContext.BeginTransaction())
                {
                    try {
                        await DbContext.MatchRepository.UpdateAsync(matchUpdate);
                        if(updateMatchModelPostParameter.Goals.Count > 0) {
                            List<Goal> goals = new List<Goal>();
                            foreach(var goalModel in updateMatchModelPostParameter.Goals) {
                                Goal goal = new Goal();
                                goal.MatchId = matchUpdate.Id;
                                goal.PlayerId = goalModel.PlayerId;
                                goal.TimeGoal = goalModel.TimeGoal;
                                goal.Deleted = (StatusDelete)goalModel.Deleted;
                                goals.Add(goal);
                            }
                            await DbContext.GoalRepository.BulkInsertAsync(goals);
                        }
                    }catch(Exception) {
                        trans.Rollback();
                    }
                    trans.Commit();
                    updateCompleted = true;
                }
            }
            return updateCompleted;
        }
    }
}
