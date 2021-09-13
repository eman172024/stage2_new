using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MeasuresServeic
{
    public class MookMeasures : GenericInterface<Measures, MeasuresDto>
    {
        private readonly AppDbCon _data;
        private readonly IMapper _mapper;

        public MookMeasures(AppDbCon data,IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<bool> Add(Measures model)
        {
            try
            {
                if (model != null) {
                    model.state = true;
                    await _data.measures.AddAsync(model);
                    await _data.SaveChangesAsync();
                    return true;
                
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Measures measures = await _data.measures.FindAsync(id);
                if (measures != null) {
                    measures.state = false;
                    _data.measures.Update(measures);
                    await _data.SaveChangesAsync();
                    return true;
                
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MeasuresDto> Get(int id)
        {
            try
            {
                Measures measures = await _data.measures.FindAsync(id);
                MeasuresDto dto = _mapper.Map<Measures, MeasuresDto>(measures);
                return dto;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<MeasuresDto>> GetAll()
        {
            try
            {
                List<Measures> measures = await _data.measures.Where(x => x.state == true).ToListAsync();

                List<MeasuresDto> list = _mapper.Map<List<Measures>, List<MeasuresDto>>(measures);
                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> Update(Measures model)
        {
            try
            {
                Measures measures = await _data.measures.FindAsync(model.MeasuresId);
                if (measures != null)
                {
                    measures.MeasuresName = model.MeasuresName;
                    _data.measures.Update(measures);
                    await _data.SaveChangesAsync();
                    return true;

                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
