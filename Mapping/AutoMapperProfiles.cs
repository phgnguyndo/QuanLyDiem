using AutoMapper;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.DaiDoi;
using BE_QuanLiDiem.Models.DTO.DayHoc;
using BE_QuanLiDiem.Models.DTO.GiangVIen;
using BE_QuanLiDiem.Models.DTO.HocPhan;
using BE_QuanLiDiem.Models.DTO.HocVien;
using BE_QuanLiDiem.Models.DTO.Khoa;
using BE_QuanLiDiem.Models.DTO.LCN;
using BE_QuanLiDiem.Models.DTO.LopHocPhan;
using BE_QuanLiDiem.Models.DTO.PhieuDiem;
using BE_QuanLiDiem.Models.DTO.User;

namespace BE_QuanLiDiem.Mapping
{
    public class AutoMapperProfiles: Profile
    {
       public AutoMapperProfiles() 
        {
            CreateMap<Khoa, KhoaDTO>().ReverseMap();
            CreateMap<Khoa, AddKhoaDTO>().ReverseMap();
            CreateMap<Khoa, UpdateKhoaDTO>().ReverseMap();

            CreateMap<BoMon, BoMonDTO>().ReverseMap();
            CreateMap<BoMon, AddBoMonDTO>().ReverseMap();
            CreateMap<BoMon, UpdateBoMonDTO>().ReverseMap();

            CreateMap<GiangVien, GiangVienDTO>().ReverseMap();
            CreateMap<GiangVien, AddGiangVienDTO>().ReverseMap();
            CreateMap<GiangVien, UpdateGiangVienDTO>().ReverseMap();

            CreateMap<HocPhan, HocPhanDTO>().ReverseMap();
            CreateMap<HocPhan, AddHocPhanDTO>().ReverseMap();
            CreateMap<HocPhan, UpdateHocPhanDTO>().ReverseMap();

            CreateMap<DayHoc, DayHocDTO>().ReverseMap();

            CreateMap<LopHocPhan, LopHocPhanDTO>().ReverseMap();
            CreateMap<LopHocPhan, AddLopHocPhanDTO>().ReverseMap();
            CreateMap<LopHocPhan, UpdateLopHocPhanDTO>().ReverseMap();

            CreateMap<PhieuDiem, PhieuDiemDTO>().ReverseMap();
            CreateMap<PhieuDiem, AddPhieuDiemDTO>().ReverseMap();
            CreateMap<PhieuDiem, UpdatePhieuDiemDTO>().ReverseMap();

            CreateMap<HocVien, HocVienDTO>().ReverseMap();
            CreateMap<HocVien, AddHocVienDTO>().ReverseMap();
            CreateMap<HocVien, UpdateHocVienDTO>().ReverseMap();

            CreateMap<LopChuyenNganh, LopCnDTO>().ReverseMap();
            CreateMap<LopChuyenNganh, AddLopCnDTO>().ReverseMap();
            CreateMap<LopChuyenNganh, UpdateLopCnDTO>().ReverseMap();

            CreateMap<DaiDoi, DaiDoiDTO>().ReverseMap();
            CreateMap<DaiDoi, AUdaiDoiDTO>().ReverseMap();
            
            CreateMap<tbl_user, tblUserDTO>().ReverseMap();




        }
    }
}
