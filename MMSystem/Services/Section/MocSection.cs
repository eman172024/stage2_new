using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMSystem.Model;
using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.Section
{
    public class MocSection : Generic2<Extrmal_Section,Extrmal_SectionDto>
    {

        public MocSection(AppDbCon db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }
        private AppDbCon _db { get; }
        private IMapper _mapper { get; }
       public async Task<bool> add( Extrmal_Section model)
         
        {
            if (model != null)

            {

              
                model.state = true;
                await _db.Extrmal_Sections.AddAsync(model);
                await _db.SaveChangesAsync();
                return true;
            }

            else
                return false;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var d = await find(id);

                if (d != null)
                {
                    if (d.state != true)
                    {
                        d.state = true;
                    }
                    else
                    {
                        d.state = false;
                    }             
                    _db.Extrmal_Sections.Update(d);
                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Extrmal_Section> find(int id)
        {
            var ext = await _db.Extrmal_Sections.FindAsync(id);

            return ext;
        }

        public async Task<Extrmal_SectionDto> Get(int id)
        {
            try
            {
                var t = await _db.Extrmal_Sections.FindAsync(id);
                var dt = _mapper.Map<Extrmal_SectionDto>(t);
                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Extrmal_SectionDto>> GetAll()
        {
            try
            {
                   List<Extrmal_Section> ext = await _db.Extrmal_Sections.Where(x => x.perent == 0 && x.state == true).ToListAsync();

                var extdto = _mapper.Map<List<Extrmal_Section>, List<Extrmal_SectionDto>>(ext);
                return extdto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Extrmal_SectionDto>> getsub(int par)
            

        {
            try
            {

                var t1 = await _db.Extrmal_Sections.Where(pa => pa.perent == par).ToListAsync();


                List<Extrmal_SectionDto> ext1 = _mapper.Map<List<Extrmal_SectionDto>>(t1);
                return ext1;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(Extrmal_Section model)
        {
            var ex1 = await find(model.id);
            if (ex1 != null)
            {
                ex1.perent = model.perent;
                ex1.type = model.type;
                ex1.state = model.state;
                ex1.Section_Name = model.Section_Name;

                _db.Extrmal_Sections.Update(ex1);
                await _db.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

       
    }
}
