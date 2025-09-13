using AutoMapper;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.ItemMaster;
using PrashantApi.Domain.Entities.ItemMaster;
using System.Threading.Tasks;
using PrashantApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrashantApi.Domain.Entities;
using PrashantApi.Infrastructure.Services;
using System;
using System.Threading.Tasks;


namespace PrashantApi.Infrastructure.Services
{
    public class ItemMasterService(IItemMasterRepository itemMasterRepository, IMapper mapper) : IItemMasterService
    {
        private readonly IItemMasterRepository _itemMasterRepository = itemMasterRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<int> AddAsync(ItemMasterDto dto)
        {
            var entity = new Domain.Entities.ItemMaster.ItemMasterModel
            {
                ItemCode = dto.ItemCode ?? string.Empty,
                ItemName = dto.ItemName ?? string.Empty,
                CategoryId = dto.CategoryId,
                SubCategoryId = dto.SubCategoryId ?? 0,
                OpeningStock = dto.OpeningStock,
                OpeningStockAsOn = dto.OpeningStockAsOn,
                ItemStock = dto.ItemStock,
                PerUnitPrice = dto.PerUnitPrice,
                CreatedBy = dto.CreatedBy ?? string.Empty,
                CreatedOn = DateTime.Now,
                ModifiedBy = dto.ModifiedBy ?? string.Empty,
                ModifiedOn = DateTime.Now,
                IsActive = dto.IsActive,
                LedgerId = dto.LedgerId,
                HsnNo = dto.HsnNo
            };

            return await _itemMasterRepository.AddAsync(entity);
        }


        public async Task<int> UpdateAsync(ItemMasterDto dto)
        {
            var entity = new ItemMasterModel
            {
                Id = dto.Id,
                ItemCode = dto.ItemCode ?? string.Empty,
                ItemName = dto.ItemName ?? string.Empty,
                CategoryId = dto.CategoryId,
                SubCategoryId = dto.SubCategoryId ?? 0,
                OpeningStock = dto.OpeningStock,
                OpeningStockAsOn = dto.OpeningStockAsOn,
                ItemStock = dto.ItemStock,
                PerUnitPrice = dto.PerUnitPrice,
                ModifiedBy = dto.ModifiedBy ?? string.Empty,
                ModifiedOn = DateTime.Now,
                IsActive = dto.IsActive,
                LedgerId = dto.LedgerId,
                HsnNo = dto.HsnNo
            };

            return await _itemMasterRepository.UpdateAsync(entity);
        }


        public async Task<List<ItemMasterDto>> GetAllAsync()
        {
            var entities = await _itemMasterRepository.GetAllAsync();

            var result = new List<ItemMasterDto>();
            foreach (var entity in entities)
            {
                result.Add(new ItemMasterDto
                {
                    Id = entity.Id,
                    ItemCode = entity.ItemCode,
                    ItemName = entity.ItemName,
                    CategoryId = entity.CategoryId,
                    SubCategoryId = entity.SubCategoryId,
                    OpeningStock = entity.OpeningStock,
                    OpeningStockAsOn = entity.OpeningStockAsOn,
                    ItemStock = entity.ItemStock,
                    PerUnitPrice = entity.PerUnitPrice,
                    CreatedBy = entity.CreatedBy,
                    CreatedOn = entity.CreatedOn,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedOn = entity.ModifiedOn,
                    IsActive = entity.IsActive,
                    LedgerId = entity.LedgerId,
                    HsnNo = entity.HsnNo
                });
            }

            return result;
        }



        public async Task<ItemMasterDto> GetByIdAsync(int id)
        {
            var entity = await _itemMasterRepository.GetByIdAsync(id);
            if (entity == null) return null;

            return new ItemMasterDto
            {
                Id = entity.Id,
                ItemCode = entity.ItemCode,
                ItemName = entity.ItemName,
                CategoryId = entity.CategoryId,
                SubCategoryId = entity.SubCategoryId,
                OpeningStock = entity.OpeningStock,
                OpeningStockAsOn = entity.OpeningStockAsOn,
                ItemStock = entity.ItemStock,
                PerUnitPrice = entity.PerUnitPrice,
                CreatedBy = entity.CreatedBy,
                CreatedOn = entity.CreatedOn,
                ModifiedBy = entity.ModifiedBy,
                ModifiedOn = entity.ModifiedOn,
                IsActive = entity.IsActive,
                LedgerId = entity.LedgerId,
                HsnNo = entity.HsnNo
            };
        }

    }
}