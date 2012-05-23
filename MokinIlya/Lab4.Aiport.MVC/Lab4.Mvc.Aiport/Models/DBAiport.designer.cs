﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.237
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab4.Mvc.Aiport.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DBAiport")]
	public partial class DBAiportDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertBank(Bank instance);
    partial void UpdateBank(Bank instance);
    partial void DeleteBank(Bank instance);
    partial void InsertReis(Reis instance);
    partial void UpdateReis(Reis instance);
    partial void DeleteReis(Reis instance);
    partial void InsertBasicReis(BasicReis instance);
    partial void UpdateBasicReis(BasicReis instance);
    partial void DeleteBasicReis(BasicReis instance);
    partial void InsertClients(Clients instance);
    partial void UpdateClients(Clients instance);
    partial void DeleteClients(Clients instance);
    partial void InsertPlains(Plains instance);
    partial void UpdatePlains(Plains instance);
    partial void DeletePlains(Plains instance);
    #endregion
		
		public DBAiportDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DBAiportConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DBAiportDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBAiportDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBAiportDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBAiportDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Bank> Bank
		{
			get
			{
				return this.GetTable<Bank>();
			}
		}
		
		public System.Data.Linq.Table<Reis> Reis
		{
			get
			{
				return this.GetTable<Reis>();
			}
		}
		
		public System.Data.Linq.Table<BasicReis> BasicReis
		{
			get
			{
				return this.GetTable<BasicReis>();
			}
		}
		
		public System.Data.Linq.Table<Clients> Clients
		{
			get
			{
				return this.GetTable<Clients>();
			}
		}
		
		public System.Data.Linq.Table<Plains> Plains
		{
			get
			{
				return this.GetTable<Plains>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Bank")]
	public partial class Bank : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Nullable<decimal> _Ammount;
		
		private System.Nullable<System.DateTime> _Date;
		
		private string _Comment;
		
		private int _CodePayment;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAmmountChanging(System.Nullable<decimal> value);
    partial void OnAmmountChanged();
    partial void OnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDateChanged();
    partial void OnCommentChanging(string value);
    partial void OnCommentChanged();
    partial void OnCodePaymentChanging(int value);
    partial void OnCodePaymentChanged();
    #endregion
		
		public Bank()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ammount", DbType="Money")]
		public System.Nullable<decimal> Ammount
		{
			get
			{
				return this._Ammount;
			}
			set
			{
				if ((this._Ammount != value))
				{
					this.OnAmmountChanging(value);
					this.SendPropertyChanging();
					this._Ammount = value;
					this.SendPropertyChanged("Ammount");
					this.OnAmmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="Date")]
		public System.Nullable<System.DateTime> Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Comment", DbType="NChar(250)")]
		public string Comment
		{
			get
			{
				return this._Comment;
			}
			set
			{
				if ((this._Comment != value))
				{
					this.OnCommentChanging(value);
					this.SendPropertyChanging();
					this._Comment = value;
					this.SendPropertyChanged("Comment");
					this.OnCommentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodePayment", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CodePayment
		{
			get
			{
				return this._CodePayment;
			}
			set
			{
				if ((this._CodePayment != value))
				{
					this.OnCodePaymentChanging(value);
					this.SendPropertyChanging();
					this._CodePayment = value;
					this.SendPropertyChanged("CodePayment");
					this.OnCodePaymentChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Reis")]
	public partial class Reis : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CodeReis;
		
		private System.Nullable<System.DateTime> _Date;
		
		private System.Nullable<int> _CodeBasicReis;
		
		private EntitySet<Clients> _Clients;
		
		private EntityRef<BasicReis> _BasicReis;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCodeReisChanging(int value);
    partial void OnCodeReisChanged();
    partial void OnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDateChanged();
    partial void OnCodeBasicReisChanging(System.Nullable<int> value);
    partial void OnCodeBasicReisChanged();
    #endregion
		
		public Reis()
		{
			this._Clients = new EntitySet<Clients>(new Action<Clients>(this.attach_Clients), new Action<Clients>(this.detach_Clients));
			this._BasicReis = default(EntityRef<BasicReis>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodeReis", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CodeReis
		{
			get
			{
				return this._CodeReis;
			}
			set
			{
				if ((this._CodeReis != value))
				{
					this.OnCodeReisChanging(value);
					this.SendPropertyChanging();
					this._CodeReis = value;
					this.SendPropertyChanged("CodeReis");
					this.OnCodeReisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="Date")]
		public System.Nullable<System.DateTime> Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodeBasicReis", DbType="Int")]
		public System.Nullable<int> CodeBasicReis
		{
			get
			{
				return this._CodeBasicReis;
			}
			set
			{
				if ((this._CodeBasicReis != value))
				{
					if (this._BasicReis.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCodeBasicReisChanging(value);
					this.SendPropertyChanging();
					this._CodeBasicReis = value;
					this.SendPropertyChanged("CodeBasicReis");
					this.OnCodeBasicReisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Reis_Clients", Storage="_Clients", ThisKey="CodeReis", OtherKey="CodeReis")]
		public EntitySet<Clients> Clients
		{
			get
			{
				return this._Clients;
			}
			set
			{
				this._Clients.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BasicReis_Reis", Storage="_BasicReis", ThisKey="CodeBasicReis", OtherKey="CodeBasicReis", IsForeignKey=true, DeleteRule="CASCADE")]
		public BasicReis BasicReis
		{
			get
			{
				return this._BasicReis.Entity;
			}
			set
			{
				BasicReis previousValue = this._BasicReis.Entity;
				if (((previousValue != value) 
							|| (this._BasicReis.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._BasicReis.Entity = null;
						previousValue.Reis.Remove(this);
					}
					this._BasicReis.Entity = value;
					if ((value != null))
					{
						value.Reis.Add(this);
						this._CodeBasicReis = value.CodeBasicReis;
					}
					else
					{
						this._CodeBasicReis = default(Nullable<int>);
					}
					this.SendPropertyChanged("BasicReis");
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
		
		private void attach_Clients(Clients entity)
		{
			this.SendPropertyChanging();
			entity.Reis = this;
		}
		
		private void detach_Clients(Clients entity)
		{
			this.SendPropertyChanging();
			entity.Reis = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BasicReis")]
	public partial class BasicReis : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CodeBasicReis;
		
		private System.Nullable<System.DateTime> _Date;
		
		private System.Nullable<decimal> _Price;
		
		private System.Nullable<int> _Interval;
		
		private string _To;
		
		private System.Nullable<int> _CodePlain;
		
		private EntitySet<Reis> _Reis;
		
		private EntityRef<Plains> _Plains;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCodeBasicReisChanging(int value);
    partial void OnCodeBasicReisChanged();
    partial void OnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDateChanged();
    partial void OnPriceChanging(System.Nullable<decimal> value);
    partial void OnPriceChanged();
    partial void OnIntervalChanging(System.Nullable<int> value);
    partial void OnIntervalChanged();
    partial void OnToChanging(string value);
    partial void OnToChanged();
    partial void OnCodePlainChanging(System.Nullable<int> value);
    partial void OnCodePlainChanged();
    #endregion
		
		public BasicReis()
		{
			this._Reis = new EntitySet<Reis>(new Action<Reis>(this.attach_Reis), new Action<Reis>(this.detach_Reis));
			this._Plains = default(EntityRef<Plains>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodeBasicReis", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CodeBasicReis
		{
			get
			{
				return this._CodeBasicReis;
			}
			set
			{
				if ((this._CodeBasicReis != value))
				{
					this.OnCodeBasicReisChanging(value);
					this.SendPropertyChanging();
					this._CodeBasicReis = value;
					this.SendPropertyChanged("CodeBasicReis");
					this.OnCodeBasicReisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="Date")]
		public System.Nullable<System.DateTime> Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Money")]
		public System.Nullable<decimal> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Interval", DbType="Int")]
		public System.Nullable<int> Interval
		{
			get
			{
				return this._Interval;
			}
			set
			{
				if ((this._Interval != value))
				{
					this.OnIntervalChanging(value);
					this.SendPropertyChanging();
					this._Interval = value;
					this.SendPropertyChanged("Interval");
					this.OnIntervalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[To]", Storage="_To", DbType="NChar(80)")]
		public string To
		{
			get
			{
				return this._To;
			}
			set
			{
				if ((this._To != value))
				{
					this.OnToChanging(value);
					this.SendPropertyChanging();
					this._To = value;
					this.SendPropertyChanged("To");
					this.OnToChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodePlain", DbType="Int")]
		public System.Nullable<int> CodePlain
		{
			get
			{
				return this._CodePlain;
			}
			set
			{
				if ((this._CodePlain != value))
				{
					if (this._Plains.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCodePlainChanging(value);
					this.SendPropertyChanging();
					this._CodePlain = value;
					this.SendPropertyChanged("CodePlain");
					this.OnCodePlainChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BasicReis_Reis", Storage="_Reis", ThisKey="CodeBasicReis", OtherKey="CodeBasicReis")]
		public EntitySet<Reis> Reis
		{
			get
			{
				return this._Reis;
			}
			set
			{
				this._Reis.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Plains_BasicReis", Storage="_Plains", ThisKey="CodePlain", OtherKey="CodePlane", IsForeignKey=true, DeleteRule="CASCADE")]
		public Plains Plains
		{
			get
			{
				return this._Plains.Entity;
			}
			set
			{
				Plains previousValue = this._Plains.Entity;
				if (((previousValue != value) 
							|| (this._Plains.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Plains.Entity = null;
						previousValue.BasicReis.Remove(this);
					}
					this._Plains.Entity = value;
					if ((value != null))
					{
						value.BasicReis.Add(this);
						this._CodePlain = value.CodePlane;
					}
					else
					{
						this._CodePlain = default(Nullable<int>);
					}
					this.SendPropertyChanged("Plains");
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
		
		private void attach_Reis(Reis entity)
		{
			this.SendPropertyChanging();
			entity.BasicReis = this;
		}
		
		private void detach_Reis(Reis entity)
		{
			this.SendPropertyChanging();
			entity.BasicReis = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Clients")]
	public partial class Clients : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CodeClient;
		
		private System.Nullable<int> _CodeReis;
		
		private System.Nullable<bool> _BookOrBuy;
		
		private EntityRef<Reis> _Reis;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCodeClientChanging(int value);
    partial void OnCodeClientChanged();
    partial void OnCodeReisChanging(System.Nullable<int> value);
    partial void OnCodeReisChanged();
    partial void OnBookOrBuyChanging(System.Nullable<bool> value);
    partial void OnBookOrBuyChanged();
    #endregion
		
		public Clients()
		{
			this._Reis = default(EntityRef<Reis>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodeClient", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CodeClient
		{
			get
			{
				return this._CodeClient;
			}
			set
			{
				if ((this._CodeClient != value))
				{
					this.OnCodeClientChanging(value);
					this.SendPropertyChanging();
					this._CodeClient = value;
					this.SendPropertyChanged("CodeClient");
					this.OnCodeClientChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodeReis", DbType="Int")]
		public System.Nullable<int> CodeReis
		{
			get
			{
				return this._CodeReis;
			}
			set
			{
				if ((this._CodeReis != value))
				{
					if (this._Reis.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCodeReisChanging(value);
					this.SendPropertyChanging();
					this._CodeReis = value;
					this.SendPropertyChanged("CodeReis");
					this.OnCodeReisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookOrBuy", DbType="Bit")]
		public System.Nullable<bool> BookOrBuy
		{
			get
			{
				return this._BookOrBuy;
			}
			set
			{
				if ((this._BookOrBuy != value))
				{
					this.OnBookOrBuyChanging(value);
					this.SendPropertyChanging();
					this._BookOrBuy = value;
					this.SendPropertyChanged("BookOrBuy");
					this.OnBookOrBuyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Reis_Clients", Storage="_Reis", ThisKey="CodeReis", OtherKey="CodeReis", IsForeignKey=true, DeleteRule="CASCADE")]
		public Reis Reis
		{
			get
			{
				return this._Reis.Entity;
			}
			set
			{
				Reis previousValue = this._Reis.Entity;
				if (((previousValue != value) 
							|| (this._Reis.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Reis.Entity = null;
						previousValue.Clients.Remove(this);
					}
					this._Reis.Entity = value;
					if ((value != null))
					{
						value.Clients.Add(this);
						this._CodeReis = value.CodeReis;
					}
					else
					{
						this._CodeReis = default(Nullable<int>);
					}
					this.SendPropertyChanged("Reis");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Plains")]
	public partial class Plains : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CodePlane;
		
		private System.Nullable<int> _NumberOfSeats;
		
		private EntitySet<BasicReis> _BasicReis;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCodePlaneChanging(int value);
    partial void OnCodePlaneChanged();
    partial void OnNumberOfSeatsChanging(System.Nullable<int> value);
    partial void OnNumberOfSeatsChanged();
    #endregion
		
		public Plains()
		{
			this._BasicReis = new EntitySet<BasicReis>(new Action<BasicReis>(this.attach_BasicReis), new Action<BasicReis>(this.detach_BasicReis));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodePlane", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CodePlane
		{
			get
			{
				return this._CodePlane;
			}
			set
			{
				if ((this._CodePlane != value))
				{
					this.OnCodePlaneChanging(value);
					this.SendPropertyChanging();
					this._CodePlane = value;
					this.SendPropertyChanged("CodePlane");
					this.OnCodePlaneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumberOfSeats", DbType="Int")]
		public System.Nullable<int> NumberOfSeats
		{
			get
			{
				return this._NumberOfSeats;
			}
			set
			{
				if ((this._NumberOfSeats != value))
				{
					this.OnNumberOfSeatsChanging(value);
					this.SendPropertyChanging();
					this._NumberOfSeats = value;
					this.SendPropertyChanged("NumberOfSeats");
					this.OnNumberOfSeatsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Plains_BasicReis", Storage="_BasicReis", ThisKey="CodePlane", OtherKey="CodePlain")]
		public EntitySet<BasicReis> BasicReis
		{
			get
			{
				return this._BasicReis;
			}
			set
			{
				this._BasicReis.Assign(value);
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
		
		private void attach_BasicReis(BasicReis entity)
		{
			this.SendPropertyChanging();
			entity.Plains = this;
		}
		
		private void detach_BasicReis(BasicReis entity)
		{
			this.SendPropertyChanging();
			entity.Plains = null;
		}
	}
}
#pragma warning restore 1591