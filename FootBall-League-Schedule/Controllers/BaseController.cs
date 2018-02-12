using ApiConfiguration;
using Business.Services;
using FootBallLeagueSchedule.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.PostParametersModels;
using System;

namespace FootBallLeagueSchedule.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IApiConfigurationManager ApiConfigurationManager;
        protected readonly ILogger Logger;
        protected readonly IUrlHelper UrlHelper;
        protected readonly IPropertyMappingService PropertyMappingService;
        protected readonly ITypeHelperService TypeHelperService;
        public BaseController(IApiConfigurationManager apiConfigurationManager,
                             ILogger<BaseController> logger,
                             IUrlHelper urlHelper,
                             IPropertyMappingService propertyMappingService,
                             ITypeHelperService typeHelperService)
        {
            ApiConfigurationManager = apiConfigurationManager ?? throw new ArgumentException("apiConfigurationManager is null");
            Logger = logger ?? throw new ArgumentException("logger is null");
            UrlHelper = urlHelper ?? throw new ArgumentException("urlHelper is null");
            PropertyMappingService = propertyMappingService ?? throw new ArgumentException("propertyMappingService is null");
            TypeHelperService = typeHelperService ?? throw new ArgumentException("typeHelperService is null");
        }

        protected virtual string CreatePlayerResourceUri(string linkUrl, BasePostParameterListModel postParametersModel, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return UrlHelper.Link(linkUrl, new
                    {
                        fields = postParametersModel.Fields,
                        orderBy = postParametersModel.OrderBy,
                        searchQuery = postParametersModel.SearchQuery,
                        pageNumber = postParametersModel.PageNumber - 1,
                        pageSize = postParametersModel.PageSize
                    });
                case ResourceUriType.NextPage:
                    return UrlHelper.Link(linkUrl, new
                    {
                        fields = postParametersModel.Fields,
                        orderBy = postParametersModel.OrderBy,
                        searchQuery = postParametersModel.SearchQuery,
                        pageNumber = postParametersModel.PageNumber + 1,
                        pageSize = postParametersModel.PageSize
                    });
                default:
                    return UrlHelper.Link(linkUrl, new
                    {
                        fields = postParametersModel.Fields,
                        orderBy = postParametersModel.OrderBy,
                        searchQuery = postParametersModel.SearchQuery,
                        pageNumber = postParametersModel.PageNumber,
                        pageSize = postParametersModel.PageSize
                    });

            }
        }
    }
}
