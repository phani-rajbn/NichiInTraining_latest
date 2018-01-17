﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinqProgramming
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="NichiInDatabase")]
	public partial class ExampleDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDeptTable(DeptTable instance);
    partial void UpdateDeptTable(DeptTable instance);
    partial void DeleteDeptTable(DeptTable instance);
    partial void InsertEmpTable(EmpTable instance);
    partial void UpdateEmpTable(EmpTable instance);
    partial void DeleteEmpTable(EmpTable instance);
    #endregion
		
		public ExampleDataContext() : 
				base(global::LinqProgramming.Properties.Settings.Default.NichiInDatabaseConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DeptTable> DeptTables
		{
			get
			{
				return this.GetTable<DeptTable>();
			}
		}
		
		public System.Data.Linq.Table<EmpTable> EmpTables
		{
			get
			{
				return this.GetTable<EmpTable>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DeptTable")]
	public partial class DeptTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DeptID;
		
		private string _DeptName;
		
		private EntitySet<EmpTable> _EmpTables;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDeptIDChanging(int value);
    partial void OnDeptIDChanged();
    partial void OnDeptNameChanging(string value);
    partial void OnDeptNameChanged();
    #endregion
		
		public DeptTable()
		{
			this._EmpTables = new EntitySet<EmpTable>(new Action<EmpTable>(this.attach_EmpTables), new Action<EmpTable>(this.detach_EmpTables));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeptID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DeptID
		{
			get
			{
				return this._DeptID;
			}
			set
			{
				if ((this._DeptID != value))
				{
					this.OnDeptIDChanging(value);
					this.SendPropertyChanging();
					this._DeptID = value;
					this.SendPropertyChanged("DeptID");
					this.OnDeptIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeptName", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string DeptName
		{
			get
			{
				return this._DeptName;
			}
			set
			{
				if ((this._DeptName != value))
				{
					this.OnDeptNameChanging(value);
					this.SendPropertyChanging();
					this._DeptName = value;
					this.SendPropertyChanged("DeptName");
					this.OnDeptNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DeptTable_EmpTable", Storage="_EmpTables", ThisKey="DeptID", OtherKey="DeptId")]
		public EntitySet<EmpTable> EmpTables
		{
			get
			{
				return this._EmpTables;
			}
			set
			{
				this._EmpTables.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_EmpTables(EmpTable entity)
		{
			this.SendPropertyChanging();
			entity.DeptTable = this;
		}
		
		private void detach_EmpTables(EmpTable entity)
		{
			this.SendPropertyChanging();
			entity.DeptTable = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EmpTable")]
	public partial class EmpTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _EmpID;
		
		private string _EmpName;
		
		private string _EmpAddress;
		
		private System.Nullable<int> _DeptId;
		
		private EntityRef<DeptTable> _DeptTable;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmpIDChanging(int value);
    partial void OnEmpIDChanged();
    partial void OnEmpNameChanging(string value);
    partial void OnEmpNameChanged();
    partial void OnEmpAddressChanging(string value);
    partial void OnEmpAddressChanged();
    partial void OnDeptIdChanging(System.Nullable<int> value);
    partial void OnDeptIdChanged();
    #endregion
		
		public EmpTable()
		{
			this._DeptTable = default(EntityRef<DeptTable>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int EmpID
		{
			get
			{
				return this._EmpID;
			}
			set
			{
				if ((this._EmpID != value))
				{
					this.OnEmpIDChanging(value);
					this.SendPropertyChanging();
					this._EmpID = value;
					this.SendPropertyChanged("EmpID");
					this.OnEmpIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string EmpName
		{
			get
			{
				return this._EmpName;
			}
			set
			{
				if ((this._EmpName != value))
				{
					this.OnEmpNameChanging(value);
					this.SendPropertyChanging();
					this._EmpName = value;
					this.SendPropertyChanged("EmpName");
					this.OnEmpNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpAddress", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string EmpAddress
		{
			get
			{
				return this._EmpAddress;
			}
			set
			{
				if ((this._EmpAddress != value))
				{
					this.OnEmpAddressChanging(value);
					this.SendPropertyChanging();
					this._EmpAddress = value;
					this.SendPropertyChanged("EmpAddress");
					this.OnEmpAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeptId", DbType="Int")]
		public System.Nullable<int> DeptId
		{
			get
			{
				return this._DeptId;
			}
			set
			{
				if ((this._DeptId != value))
				{
					if (this._DeptTable.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDeptIdChanging(value);
					this.SendPropertyChanging();
					this._DeptId = value;
					this.SendPropertyChanged("DeptId");
					this.OnDeptIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DeptTable_EmpTable", Storage="_DeptTable", ThisKey="DeptId", OtherKey="DeptID", IsForeignKey=true)]
		public DeptTable DeptTable
		{
			get
			{
				return this._DeptTable.Entity;
			}
			set
			{
				DeptTable previousValue = this._DeptTable.Entity;
				if (((previousValue != value) 
							|| (this._DeptTable.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DeptTable.Entity = null;
						previousValue.EmpTables.Remove(this);
					}
					this._DeptTable.Entity = value;
					if ((value != null))
					{
						value.EmpTables.Add(this);
						this._DeptId = value.DeptID;
					}
					else
					{
						this._DeptId = default(Nullable<int>);
					}
					this.SendPropertyChanged("DeptTable");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
