using Microsoft.AspNetCore.Mvc;
using NetCoreApiExtensions.Shared.Responses;
using NetCoreApiExtensions.WebApi.Discovery;

namespace NetCoreApiExtensions.WebApi.TestHarness.v2_0_beta.Controllers
{
    /// <summary>
    /// Test Controller in v 2.0 beta
    /// </summary>
    [VersionedApiController]
    public class TestNameController : ControllerBase
    {
        /// <summary>
        /// Just Returns false
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<DataResponse<bool>> GetBool()
        {
            return await Task.FromResult(DataResponse<bool>.Create(false));
        }
    }
}
