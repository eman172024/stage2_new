using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.MeasuresServeic
{
    public class MookMeasures : GenericInterface<Measures, Measures>
    {
        private readonly AppDbCon _data;

        public MookMeasures(AppDbCon data)
        {
            _data = data;
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

        public async Task<Measures> Get(int id)
        {
            try
            {
                Measures measures = await _data.measures.FindAsync(id);
                return measures;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Measures>> GetAll()
        {
            try
            {
                List<Measures> measures = await _data.measures.Where(x => x.state == true).ToListAsync();
                return measures;
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
