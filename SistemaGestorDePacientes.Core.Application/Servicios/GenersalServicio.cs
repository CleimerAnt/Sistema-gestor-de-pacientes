﻿using AutoMapper;
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;


namespace SistemaGestorDePacientes.Core.Application.Servicios
{
    public class GeneralServicio<ViewModel, postViewModel, Entity> : IGenericServicio<ViewModel, postViewModel, Entity> 
        where ViewModel : class 
        where postViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public GeneralServicio(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<postViewModel> AddAsync(postViewModel vm)
        {
            
            Entity entity = _mapper.Map<Entity>(vm);    
            
            entity = await _repository.AddAsync(entity);

            postViewModel postVm = _mapper.Map<postViewModel>(entity);  

            return postVm;
        }

        public virtual async Task Editar(postViewModel vm, int ID)
        {
            Entity entity = _mapper.Map<Entity>(vm);

            await _repository.UpdateAsync(entity, ID);
        }

        public async Task Eliminar(int Id)
        {
            Entity entity = await _repository.GetByIdAsync(Id);

            await _repository.Remove(entity);
        }

        public virtual async Task <List<ViewModel>> GetAllAsync()
        {
            var Lista =  await _repository.GetAllAsync();

           return _mapper.Map<List<ViewModel>>(Lista);
        }

        public async Task<postViewModel> GetById(int Id)
        {
            Entity entity = await _repository.GetByIdAsync(Id);

            postViewModel postVm = _mapper.Map<postViewModel>(entity);

            return postVm;
        }

    }
}
