
/*---------------------------------------------------------
// Copyright (C) 2015 恒亿慧通
//
// 文件名：AssetsCategoryBLL.cs
// 文件功能描述： 好像是资产类别吧
// 作者：renguoqiang
// 
// 创建时间：2015年7月16日
//
// 修改标识：rengq gaile 怎么样
// 修改描述：renguoang
//你想怎样，光说不练
//这个世界太疯狂
//等着你来啦，git比较爽
//git NB AND git 分支，等着你的NB
 * 新的分支管理策略
//--------------------------------------------------------*/



using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using HYHT.Common;
using HYHT.ITIL.Entity;
using HYHT.ITIL.Data;
 

namespace HYHT.ITIL.Domain
{
	public class AssetsCategoryBLL
	{
        public AssetsCategoryModel Get(string p_AssetsCategoryID)
        {
            AssetsCategoryDal m_AssetsCategoryDal = new AssetsCategoryDal();
			var m_Result = m_AssetsCategoryDal.Get(p_AssetsCategoryID);
			return m_Result;
        }

        public List<AssetsCategoryModel> GetALL()
        {
            AssetsCategoryDal m_AssetsCategoryDal = new AssetsCategoryDal();
            var m_Result = m_AssetsCategoryDal.GetAll();
            return m_Result;
        }

        public List<AssetsCategoryModel> GetList(AssetsCategorySearch p_AssetsCategorySearch, PageInfoDom p_PageInfoDom)
        {
            AssetsCategoryDal m_AssetsCategoryDal = new AssetsCategoryDal();
			var m_Result = m_AssetsCategoryDal.GetList(p_AssetsCategorySearch,p_PageInfoDom);
            return m_Result;
        }

        public AssetsCategoryModel Add(AssetsCategoryModel p_AssetsCategoryModel)
        {
            AssetsCategoryDal m_AssetsCategoryDal = new AssetsCategoryDal();
            p_AssetsCategoryModel.AssetsCategoryID = IDHelper.GetNewGuid().ToString();
            p_AssetsCategoryModel.DataState = DataStateEnumType.Valid;
            p_AssetsCategoryModel.TreeNo = CommonDal.GetMaxTreeNo(TreeTableEnum.AssetCategoryTable, p_AssetsCategoryModel.AddFTreeNo, TreeLevelEnum.ChildLevel);
            p_AssetsCategoryModel.QuanPinIndex = Pinyin.GetPinyin(p_AssetsCategoryModel.AssetsCategoryName).Replace(" ", "");
            p_AssetsCategoryModel.JianPinIndex = Pinyin.GetInitials(p_AssetsCategoryModel.AssetsCategoryName).ToLower();
   
            return m_AssetsCategoryDal.Add(p_AssetsCategoryModel);
        }

        public AssetsCategoryModel Update(AssetsCategoryEntity p_AssetsCategoryEntity)
        { 
			AssetsCategoryDal m_AssetsCategoryDal = new AssetsCategoryDal();
			return m_AssetsCategoryDal.Update(p_AssetsCategoryEntity);
        }
		
		public void Delete(long p_AssetsCategoryID )
        {
			AssetsCategoryDal m_AssetsCategoryDal = new AssetsCategoryDal();
			m_AssetsCategoryDal.Delete(p_AssetsCategoryID);
 
        }

        public bool VerifySameName(string TreeNo, TreeLevelEnum Level, string DeptName)
        {

            return CommonDal.VerifySameName(TreeTableEnum.DepartmentTable, TreeNo, Level, DeptName);
        }


        /// <summary>
        /// 获取子集资产类别数量
        /// </summary>
        /// <param name="TreeNo"></param>
        /// <returns></returns>
        public int GetChildAssetsCategory(string TreeNo)
        {
            AssetsCategoryDal m_AssetsCategoryDal = new AssetsCategoryDal();
            int childDeptCount = m_AssetsCategoryDal.GetChildAssetsCategory(TreeNo);
            return childDeptCount;
        }
		
	}
}
