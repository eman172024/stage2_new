using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;

namespace MMSystem.Services.MeasuresServeic
{
    public class MookClasificationSubject : GenericInterface<ClasificationSubject, ClasificationSubject>
    {
        private readonly AppDbCon _appDbCon;

        public MookClasificationSubject(AppDbCon appDbCon)
        {
            _appDbCon = appDbCon;
        }
        public async Task<bool> Add(ClasificationSubject model)
        {
            try
            {
                if (model != null) {
                    await _appDbCon.clasifications.AddAsync(model);
                    await _appDbCon.SaveChangesAsync();
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
                ClasificationSubject subject = await _appDbCon.clasifications.FindAsync(id);
              if (subject != null) {

                    subject.state = false;
                    _appDbCon.clasifications.Update(subject);
                    await _appDbCon.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ClasificationSubject> Get(int id)
        {
            try
            {
                ClasificationSubject subject = await _appDbCon.clasifications.FindAsync(id);

                return subject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ClasificationSubject>> GetAll()
        {
            try
            {
                List<ClasificationSubject> list = await _appDbCon.clasifications.ToListAsync();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<bool> Update(ClasificationSubject model)
        {
            try
            {
                ClasificationSubject subject = await _appDbCon.clasifications.FindAsync(model.Id);
                if (model != null) {
                    subject.Name = model.Name;
                    _appDbCon.clasifications.Update(subject);
                    await _appDbCon.SaveChangesAsync();
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
