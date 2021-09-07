using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;

namespace MMSystem.Services.MeasuresServeic
{
    public class MookClasificationSubject : GenericInterface<ClasificationSubject, ClasificationSubjectDto>
    {
        private readonly AppDbCon _appDbCon;
        private readonly IMapper _mapper;

        public MookClasificationSubject(AppDbCon appDbCon,IMapper mapper)
        {
            _appDbCon = appDbCon;
            _mapper = mapper;
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

        public async Task<ClasificationSubjectDto> Get(int id)
        {
            try
            {
                ClasificationSubject subject = await _appDbCon.clasifications.FindAsync(id);

                ClasificationSubjectDto dto = _mapper.Map<ClasificationSubject, ClasificationSubjectDto>(subject);

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ClasificationSubjectDto>> GetAll()
        {
            try
            {
                List<ClasificationSubject> list = await _appDbCon.clasifications.ToListAsync();
                List<ClasificationSubjectDto> listof = _mapper.Map<List<ClasificationSubject>, List<ClasificationSubjectDto>>(list);

                return listof;
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
