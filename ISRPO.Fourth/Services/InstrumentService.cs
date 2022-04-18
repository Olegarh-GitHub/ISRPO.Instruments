using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ISRPO.Fourth.Domain.Models;
using ISRPO.Fourth.Domain.Repositories.Base;
using ISRPO.Fourth.DTO;

namespace ISRPO.Fourth.Services
{
    public class InstrumentService
    {
        private readonly IRepository<Instrument> _instruments;
        private readonly IMapper _mapper;
        
        public InstrumentService(IRepository<Instrument> instruments, IMapper mapper)
        {
            _instruments = instruments;
            _mapper = mapper;
        }

        public IQueryable<InstrumentDTO> Read()
        {
            return _instruments.Read().Select(instrument => _mapper.Map<InstrumentDTO>(instrument));
        }

        public async Task<InstrumentDTO> Create(InstrumentDTO instrumentDto)
        {
            var instrument = await _instruments.Create(_mapper.Map<Instrument>(instrumentDto));

            return _mapper.Map<InstrumentDTO>(instrument);
        }
        
        public async Task<InstrumentDTO> Update(InstrumentDTO instrumentDto)
        {
            var instrument = await _instruments.Update(_mapper.Map<Instrument>(instrumentDto));

            return _mapper.Map<InstrumentDTO>(instrument);
        }
        
        public async Task<bool> Delete(InstrumentDTO instrumentDto)
        {
            return await _instruments.Delete(_mapper.Map<Instrument>(instrumentDto));
        }
    }
}