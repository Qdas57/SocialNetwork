using AutoMapper;

namespace SocialNetwork.Controllers
{
    public class AutoMapperController
    {
        private readonly IMapper _mapper;

        public AutoMapperController(IMapper mapper)
        {
            _mapper = mapper;
        }

    }
}
