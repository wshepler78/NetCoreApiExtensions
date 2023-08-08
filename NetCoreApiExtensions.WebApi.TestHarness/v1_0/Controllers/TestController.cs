using Microsoft.AspNetCore.Mvc;
using NetCoreApiExtensions.Shared.Exceptions;
using NetCoreApiExtensions.Shared.Responses;
using NetCoreApiExtensions.Shared.Utilities;
using NetCoreApiExtensions.WebApi.Discovery;
using NetCoreApiExtensions.WebApi.TestHarness.TestModels;

namespace NetCoreApiExtensions.WebApi.TestHarness.v1_0.Controllers
{
    /// <summary>
    /// Version 1 test controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [VersionedApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// Just Returns true
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<DataResponse<bool>> GetBool()
        {
            return await Task.FromResult(DataResponse<bool>.Create(true));
        }

        /// <summary>
        /// Just Returns the Guid
        /// </summary>
        /// <returns></returns>
        [HttpGet("{testId:Guid}/AndInteger/{ThisIsAReallyCrazyVariableNameId:int}")]
        public async Task<DataResponse<Guid>> GetInteger([FromRoute] Guid testId, [FromRoute] int thisIsAReallyCrazyVariableNameId)
        {
            return await Task.FromResult(DataResponse<Guid>.Create(testId));
        }

        /// <summary>
        /// Just blows up.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("boom")]
        public DataResponse<bool> GetBoom()
        {
            throw new NotFoundException("It's not here, like, for sure.");
        }

        /// <summary>
        /// Tries to return a known dinosaur type from the supplied string.
        /// </summary>
        /// <param name="dinosaurType">Dinosaur string name <see cref="DinosaurType"/></param>
        /// <param name="useDefault">If true, will return the default type if no match is found. If false, will error if not found</param>
        [HttpGet]
        [Route("dinosaurs/{dinosaurType}")]
        public DataResponse<DinosaurType?> GetDinosaurType([FromRoute] string dinosaurType, [FromQuery] bool useDefault = true)
        {
            DinosaurType? result;
            if (useDefault)
            {
                result = EnumHelper<DinosaurType>.GetValueOrDefault(dinosaurType);
            }
            else
            {
                result = Enum.Parse<DinosaurType>(dinosaurType, true);
            }

            return DataResponse<DinosaurType?>.Create(result); 
        }
    }
}
