using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataSyncAPI
{
    public partial class eretailContext : DbContext
    {
        public eretailContext()
        {
        }

        public eretailContext(DbContextOptions<eretailContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Commission> Commission { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Diningtable> Diningtable { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Inventorydetail> Inventorydetail { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Invoicedetail> Invoicedetail { get; set; }
        public virtual DbSet<Menumaster> Menumaster { get; set; }
        public virtual DbSet<Orderdetail> Orderdetail { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Ordertype> Ordertype { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Paymenttype> Paymenttype { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Productcomboitems> Productcomboitems { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Purchaseorderdetail> Purchaseorderdetail { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Shippingorder> Shippingorder { get; set; }
        public virtual DbSet<Shippingprovider> Shippingprovider { get; set; }
        public virtual DbSet<Shippingrate> Shippingrate { get; set; }
        public virtual DbSet<Staffinventory> Staffinventory { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Taxrate> Taxrate { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Transactiondetail> Transactiondetail { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Unitrelation> Unitrelation { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Userrole> Userrole { get; set; }
        public virtual DbSet<Ztransactions> Ztransactions { get; set; }

        // Unable to generate entity type for table 'public.heldsales'. Please see the warning messages.
        // Unable to generate entity type for table 'public.purchaseorderreceive'. Please see the warning messages.
        // Unable to generate entity type for table 'public.purchaseorderreturn'. Please see the warning messages.
        // Unable to generate entity type for table 'public.zpayment'. Please see the warning messages.
        // Unable to generate entity type for table 'public.cashdrawer'. Please see the warning messages.
        // Unable to generate entity type for table 'public.shippingregion'. Please see the warning messages.
        // Unable to generate entity type for table 'public.purchaseorderpayment'. Please see the warning messages.
        // Unable to generate entity type for table 'public.suppliercategory'. Please see the warning messages.
        // Unable to generate entity type for table 'public.batch'. Please see the warning messages.
        // Unable to generate entity type for table 'public.purchaseorderreceivingdetail'. Please see the warning messages.
        // Unable to generate entity type for table 'public.purchaseorder'. Please see the warning messages.
        // Unable to generate entity type for table 'public.expensecategory'. Please see the warning messages.
        // Unable to generate entity type for table 'public.giftvoucher'. Please see the warning messages.
        // Unable to generate entity type for table 'public.ztransactiondetails'. Please see the warning messages.
        // Unable to generate entity type for table 'public.zinventory'. Please see the warning messages.
        // Unable to generate entity type for table 'public.purchaseorderexpense'. Please see the warning messages.
        // Unable to generate entity type for table 'public.permissions'. Please see the warning messages.
        // Unable to generate entity type for table 'public.expenses'. Please see the warning messages.
        // Unable to generate entity type for table 'public.syncmarker'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=eretail;Username=postgres;Password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.AlbumArtUrl)
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("'/Content/Images/placeholder.gif'::character varying");

                entity.Property(e => e.Title).HasMaxLength(160);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("Album_ArtistId_fkey");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("Album_GenreId_fkey");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.ClaimType).HasMaxLength(256);

                entity.Property(e => e.ClaimValue).HasMaxLength(256);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_User_Id");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.PasswordHash).HasMaxLength(256);

                entity.Property(e => e.PhoneNumber).HasMaxLength(256);

                entity.Property(e => e.SecurityStamp).HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("branch");

                entity.HasIndex(e => e.Id)
                    .HasName("branches_id_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('branches_id_seq'::regclass)");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .ForNpgsqlHasComment("phone");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.ToTable("cart");

                entity.Property(e => e.RecordId).HasDefaultValueSql("nextval('\"Cart_RecordId_seq\"'::regclass)");

                entity.Property(e => e.CartId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Productno).HasColumnName("productno");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Categoryno);

                entity.ToTable("category");

                entity.Property(e => e.Categoryno).HasColumnName("categoryno");

                entity.Property(e => e.Categoryname).HasColumnName("categoryname");

                entity.Property(e => e.Description).HasColumnName("description");
            });

            modelBuilder.Entity<Commission>(entity =>
            {
                entity.ToTable("commission");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calculation).HasColumnName("calculation");

                entity.Property(e => e.Ordertype).HasColumnName("ordertype");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("numeric(10,2)");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('company_companyid_seq'::regclass)");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Card).HasColumnName("card");

                entity.Property(e => e.Cash).HasColumnName("cash");

                entity.Property(e => e.Cheque).HasColumnName("cheque");

                entity.Property(e => e.Companyname).HasColumnName("companyname");

                entity.Property(e => e.Defaultcurrency).HasColumnName("defaultcurrency");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Firstinvoice).HasColumnName("firstinvoice");

                entity.Property(e => e.Invoicemessage).HasColumnName("invoicemessage");

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasColumnType("character varying");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(254);

                entity.Property(e => e.Receiptmessage).HasColumnName("receiptmessage");

                entity.Property(e => e.Showtax)
                    .HasColumnName("showtax")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Tax1).HasColumnName("tax1");

                entity.Property(e => e.Tax2).HasColumnName("tax2");

                entity.Property(e => e.Tax3).HasColumnName("tax3");

                entity.Property(e => e.Taxmessage).HasColumnName("taxmessage");

                entity.Property(e => e.Tinnumber).HasColumnName("tinnumber");

                entity.Property(e => e.Website).HasColumnName("website");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('company_companyid_seq'::regclass)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("character varying");

                entity.Property(e => e.Creditlimit).HasColumnName("creditlimit");

                entity.Property(e => e.Customername).HasColumnName("customername");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.Regionid).HasColumnName("regionid");
            });

            modelBuilder.Entity<Diningtable>(entity =>
            {
                entity.ToTable("diningtable");

                entity.HasIndex(e => e.Tablename)
                    .HasName("UK")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Branchid).HasColumnName("branchid");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(254);

                entity.Property(e => e.Tablename)
                    .IsRequired()
                    .HasColumnName("tablename")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Inventorydetail>(entity =>
            {
                entity.ToTable("inventorydetail");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('inventory_id_seq'::regclass)");

                entity.Property(e => e.Balance)
                    .HasColumnName("balance")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Batchno).HasColumnName("batchno");

                entity.Property(e => e.Branchid).HasColumnName("branchid");

                entity.Property(e => e.Buyprice).HasColumnName("buyprice");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Datein).HasColumnName("datein");

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.Initial)
                    .HasColumnName("initial")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Inventoryid).HasColumnName("inventoryid");

                entity.Property(e => e.Issuedstaffid).HasColumnName("issuedstaffid");

                entity.Property(e => e.Mode)
                    .HasColumnName("mode")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Netamount).HasColumnName("netamount");

                entity.Property(e => e.Pono).HasColumnName("pono");

                entity.Property(e => e.Productno).HasColumnName("productno");

                entity.Property(e => e.Purchaseid).HasColumnName("purchaseid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Saleprice)
                    .HasColumnName("saleprice")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Staffid).HasColumnName("staffid");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.Property(e => e.Tax1).HasColumnName("tax1");

                entity.Property(e => e.Tax2).HasColumnName("tax2");

                entity.Property(e => e.Tax3).HasColumnName("tax3");

                entity.Property(e => e.Taxamount).HasColumnName("taxamount");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Unitid).HasColumnName("unitid");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Branchid).HasColumnName("branchid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.Duedate).HasColumnName("duedate");

                entity.Property(e => e.Invoicedate).HasColumnName("invoicedate");

                entity.Property(e => e.Invoiceid)
                    .HasColumnName("invoiceid")
                    .HasColumnType("character varying");

                entity.Property(e => e.Isquotation).HasColumnName("isquotation");

                entity.Property(e => e.Netamount)
                    .HasColumnName("netamount")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Proposaldetail)
                    .HasColumnName("proposaldetail")
                    .HasColumnType("character varying");

                entity.Property(e => e.Staffid).HasColumnName("staffid");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Taxamount)
                    .HasColumnName("taxamount")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("numeric(10,2)");
            });

            modelBuilder.Entity<Invoicedetail>(entity =>
            {
                entity.ToTable("invoicedetail");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('invdetails_id_seq'::regclass)");

                entity.Property(e => e.Barcode).HasColumnName("barcode");

                entity.Property(e => e.Branchid).HasColumnName("branchid");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Invoicedate)
                    .HasColumnName("invoicedate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Invoiceid).HasColumnName("invoiceid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Saleprice)
                    .HasColumnName("saleprice")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Staffid).HasColumnName("staffid");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(10,2)");
            });

            modelBuilder.Entity<Menumaster>(entity =>
            {
                entity.ToTable("menumaster");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('menumaster_seq'::regclass)");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("timestamp(3) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Ikon)
                    .IsRequired()
                    .HasColumnName("ikon")
                    .HasMaxLength(100);

                entity.Property(e => e.Menuid)
                    .IsRequired()
                    .HasColumnName("menuid")
                    .HasMaxLength(30);

                entity.Property(e => e.Menuname)
                    .IsRequired()
                    .HasColumnName("menuname")
                    .HasMaxLength(30);

                entity.Property(e => e.Menuurl)
                    .IsRequired()
                    .HasColumnName("menuurl")
                    .HasMaxLength(500);

                entity.Property(e => e.Ordering)
                    .HasColumnName("ordering")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ParentMenuid)
                    .IsRequired()
                    .HasColumnName("parent_menuid")
                    .HasMaxLength(30);

                entity.Property(e => e.UseYn)
                    .HasColumnName("use_yn")
                    .HasDefaultValueSql("'Y'::bpchar");

                entity.Property(e => e.UserRoll)
                    .IsRequired()
                    .HasColumnName("user_roll")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.ToTable("orderdetail");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('\"OrderDetail_OrderDetailId_seq\"'::regclass)");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Productno).HasColumnName("productno");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.ProductnoNavigation)
                    .WithMany(p => p.Orderdetail)
                    .HasForeignKey(d => d.Productno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prod");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('order_id_seq'::regclass)");

                entity.Property(e => e.Branchid).HasColumnName("branchid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Datein)
                    .HasColumnName("datein")
                    .HasColumnType("timestamp(2) without time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Delivery)
                    .HasColumnName("delivery")
                    .HasColumnType("numeric(10,2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.Ordertotal).HasColumnName("ordertotal");

                entity.Property(e => e.Ordertype).HasColumnName("ordertype");

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Staffid).HasColumnName("staffid");

                entity.Property(e => e.Voided)
                    .HasColumnName("voided")
                    .HasDefaultValueSql("false");
            });

            modelBuilder.Entity<Ordertype>(entity =>
            {
                entity.ToTable("ordertype");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amountdue)
                    .HasColumnName("amountdue")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Amountpaid)
                    .HasColumnName("amountpaid")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Changegiven)
                    .HasColumnName("changegiven")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Datein).HasColumnName("datein");

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Paymenttype).HasColumnName("paymenttype");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.Refcode)
                    .HasColumnName("refcode")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.Staffid)
                    .HasColumnName("staffid")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Transactionid).HasColumnName("transactionid");
            });

            modelBuilder.Entity<Paymenttype>(entity =>
            {
                entity.ToTable("paymenttype");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Productno);

                entity.ToTable("product");

                entity.HasIndex(e => e.Unit)
                    .HasName("fki_productbufk");

                entity.Property(e => e.Productno)
                    .HasColumnName("productno")
                    .HasDefaultValueSql("nextval('product_seq'::regclass)");

                entity.Property(e => e.Barcode).HasColumnName("barcode");

                entity.Property(e => e.Buyprice)
                    .HasColumnName("buyprice")
                    .HasColumnType("numeric(10,2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Categoryno)
                    .HasColumnName("categoryno")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Expires).HasColumnName("expires");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasDefaultValueSql("'placeholder.png'::text");

                entity.Property(e => e.Productcode)
                    .HasColumnName("productcode")
                    .HasColumnType("character varying");

                entity.Property(e => e.Producttype)
                    .HasColumnName("producttype")
                    .HasDefaultValueSql("'Standard'::text");

                entity.Property(e => e.Purchaseunit).HasColumnName("purchaseunit");

                entity.Property(e => e.Reorderlevel).HasColumnName("reorderlevel");

                entity.Property(e => e.Saleprice)
                    .HasColumnName("saleprice")
                    .HasColumnType("numeric(10,2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Saleprice2)
                    .HasColumnName("saleprice2")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Saleunit)
                    .HasColumnName("saleunit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Active'::text");

                entity.Property(e => e.Tax1)
                    .HasColumnName("tax1")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Tax2)
                    .HasColumnName("tax2")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Tax3)
                    .HasColumnName("tax3")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Productcomboitems>(entity =>
            {
                entity.HasKey(e => new { e.Combono, e.Productno });

                entity.ToTable("productcomboitems");

                entity.HasIndex(e => e.Productno)
                    .HasName("fki_ufk");

                entity.Property(e => e.Combono).HasColumnName("combono");

                entity.Property(e => e.Productno).HasColumnName("productno");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('productcombo_id_seq'::regclass)");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.HasOne(d => d.ProductnoNavigation)
                    .WithMany(p => p.Productcomboitems)
                    .HasForeignKey(d => d.Productno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productbno");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("purchase");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('inventory_id_seq'::regclass)");

                entity.Property(e => e.Balance)
                    .HasColumnName("balance")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Batchno).HasColumnName("batchno");

                entity.Property(e => e.Branchid).HasColumnName("branchid");

                entity.Property(e => e.Buyprice).HasColumnName("buyprice");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Datein)
                    .HasColumnName("datein")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Initial)
                    .HasColumnName("initial")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Inventoryid).HasColumnName("inventoryid");

                entity.Property(e => e.Mode)
                    .HasColumnName("mode")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Netamount).HasColumnName("netamount");

                entity.Property(e => e.Pono).HasColumnName("pono");

                entity.Property(e => e.Productno).HasColumnName("productno");

                entity.Property(e => e.PurchaseTypeId).HasColumnName("PurchaseTypeID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Saleprice)
                    .HasColumnName("saleprice")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Staffid).HasColumnName("staffid");

                entity.Property(e => e.Staffname).HasColumnName("staffname");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.Property(e => e.Tax1).HasColumnName("tax1");

                entity.Property(e => e.Tax2).HasColumnName("tax2");

                entity.Property(e => e.Tax3).HasColumnName("tax3");

                entity.Property(e => e.Taxamount).HasColumnName("taxamount");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Unitid).HasColumnName("unitid");
            });

            modelBuilder.Entity<Purchaseorderdetail>(entity =>
            {
                entity.ToTable("purchaseorderdetail");

                entity.Property(e => e.PurchaseOrderDetailId)
                    .HasColumnName("PurchaseOrderDetailID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasMaxLength(25);

                entity.Property(e => e.ModifiedOn).HasMaxLength(25);

                entity.Property(e => e.Pono).HasColumnName("PONo");

                entity.Property(e => e.ProductNo)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Shippingorder>(entity =>
            {
                entity.ToTable("shippingorder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Providerid).HasColumnName("providerid");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.Regionid).HasColumnName("regionid");

                entity.Property(e => e.Transactionid).HasColumnName("transactionid");
            });

            modelBuilder.Entity<Shippingprovider>(entity =>
            {
                entity.ToTable("shippingprovider");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('shippingsuppliers_suppid_seq'::regclass)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("character varying");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Providername).HasColumnName("providername");
            });

            modelBuilder.Entity<Shippingrate>(entity =>
            {
                entity.HasKey(e => new { e.Providerid, e.Regionid });

                entity.ToTable("shippingrate");

                entity.Property(e => e.Providerid).HasColumnName("providerid");

                entity.Property(e => e.Regionid).HasColumnName("regionid");

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("numeric(10,2)");
            });

            modelBuilder.Entity<Staffinventory>(entity =>
            {
                entity.ToTable("staffinventory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('inventorystaff_id_seq'::regclass)");

                entity.Property(e => e.Detail).HasColumnName("detail");

                entity.Property(e => e.Issuedate).HasColumnName("issuedate");

                entity.Property(e => e.Issuedby).HasColumnName("issuedby");

                entity.Property(e => e.Productno).HasColumnName("productno");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Returndate).HasColumnName("returndate");

                entity.Property(e => e.Returned)
                    .HasColumnName("returned")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Staffid).HasColumnName("staffid");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('suppliers_suppid_seq'::regclass)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("character varying");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Suppliername).HasColumnName("suppliername");
            });

            modelBuilder.Entity<Taxrate>(entity =>
            {
                entity.HasKey(e => e.Taxid);

                entity.ToTable("taxrate");

                entity.Property(e => e.Taxid)
                    .HasColumnName("taxid")
                    .HasDefaultValueSql("nextval('taxsetting_taxid_seq'::regclass)");

                entity.Property(e => e.Taxname).HasColumnName("taxname");

                entity.Property(e => e.Taxrate1)
                    .HasColumnName("taxrate")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transaction");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('transactionid_seq'::regclass)");

                entity.Property(e => e.Balance)
                    .HasColumnName("balance")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Branchid).HasColumnName("branchid");

                entity.Property(e => e.Commission)
                    .HasColumnName("commission")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Datein)
                    .HasColumnName("datein")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Delivery)
                    .HasColumnName("delivery")
                    .HasColumnType("numeric(10,2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasMaxLength(512);

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Invoiceno).HasColumnName("invoiceno");

                entity.Property(e => e.Netamount)
                    .HasColumnName("netamount")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Staffid).HasColumnName("staffid");

                entity.Property(e => e.Taxamount)
                    .HasColumnName("taxamount")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Transactiontype).HasColumnName("transactiontype");
            });

            modelBuilder.Entity<Transactiondetail>(entity =>
            {
                entity.ToTable("transactiondetail");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('transactiondetails_id_seq'::regclass)");

                entity.Property(e => e.Barcode).HasColumnName("barcode");

                entity.Property(e => e.Branchid).HasColumnName("branchid");

                entity.Property(e => e.Buyprice)
                    .HasColumnName("buyprice")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Datein)
                    .HasColumnName("datein")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Invoiceno).HasColumnName("invoiceno");

                entity.Property(e => e.Productno).HasColumnName("productno");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Saleprice)
                    .HasColumnName("saleprice")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Staffid).HasColumnName("staffid");

                entity.Property(e => e.Tax1)
                    .HasColumnName("tax1")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Tax2)
                    .HasColumnName("tax2")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Tax3)
                    .HasColumnName("tax3")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Transactionid).HasColumnName("transactionid");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("unit");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('units_id_seq'::regclass)");

                entity.Property(e => e.Alias).HasColumnName("alias");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Unitrelation>(entity =>
            {
                entity.ToTable("unitrelation");

                entity.HasIndex(e => e.Baseunit)
                    .HasName("fki_bufk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasColumnType("character varying");

                entity.Property(e => e.Baseunit).HasColumnName("baseunit");

                entity.Property(e => e.Conversionfactor)
                    .HasColumnName("conversionfactor")
                    .HasColumnType("numeric(10,8)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Multiplier)
                    .HasColumnName("multiplier")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.BaseunitNavigation)
                    .WithMany(p => p.Unitrelation)
                    .HasForeignKey(d => d.Baseunit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("unitrelation_baseunit_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('user_id_seq'::regclass)");

                entity.Property(e => e.AccessFailedCount).HasDefaultValueSql("0");

                entity.Property(e => e.ApplicationName).HasColumnType("character varying");

                entity.Property(e => e.Branchcode)
                    .HasColumnName("branchcode")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Branchid).HasColumnName("branchid");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Hired)
                    .HasColumnName("hired")
                    .HasColumnType("character varying");

                entity.Property(e => e.PhoneConfirmed).HasDefaultValueSql("false");

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasColumnType("character varying");

                entity.Property(e => e.ReceiveStock).HasDefaultValueSql("0");

                entity.Property(e => e.Retail).HasColumnName("retail");

                entity.Property(e => e.SecurityStamp).HasColumnType("character varying");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Wholesale).HasColumnName("wholesale");
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId });

                entity.ToTable("userrole");

                entity.HasIndex(e => e.RoleId)
                    .HasName("UserRoles_RoleId");

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.ApplicationName)
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'eRetail'::character varying");
            });

            modelBuilder.Entity<Ztransactions>(entity =>
            {
                entity.ToTable("ztransactions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Balance).HasDefaultValueSql("0");

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Tdate).HasColumnName("TDate");

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("0");

                entity.Property(e => e.VatAmount).HasDefaultValueSql("0");
            });

            modelBuilder.HasSequence("atvoucher_atvoucherid_seq");

            modelBuilder.HasSequence("batches_id_seq");

            modelBuilder.HasSequence("branches_id_seq");

            modelBuilder.HasSequence("Cart_RecordId_seq");

            modelBuilder.HasSequence("company_companyid_seq");

            modelBuilder.HasSequence("customer_id_seq");

            modelBuilder.HasSequence("expenses_Id_seq");

            modelBuilder.HasSequence("invdetails_id_seq").StartsAt(174);

            modelBuilder.HasSequence("inventory_id_seq");

            modelBuilder.HasSequence("inventorystaff_id_seq");

            modelBuilder.HasSequence("menumaster_seq");

            modelBuilder.HasSequence("order_id_seq").StartsAt(2);

            modelBuilder.HasSequence("OrderDetail_OrderDetailId_seq");

            modelBuilder.HasSequence("payment_id_seq");

            modelBuilder.HasSequence("permissions_Id_seq");

            modelBuilder.HasSequence("product_seq");

            modelBuilder.HasSequence("productcombo_id_seq");

            modelBuilder.HasSequence("productno_seq");

            modelBuilder.HasSequence("purchase_order_expense_ExpenseNo_seq");

            modelBuilder.HasSequence("purchase_order_payment_PaymentNo_seq");

            modelBuilder.HasSequence("purchase_order_PONo_seq");

            modelBuilder.HasSequence("purchase_order_receive_ReceiveId_seq");

            modelBuilder.HasSequence("purchase_order_receiving_detail_DeliveryId_seq");

            modelBuilder.HasSequence("purchase_order_return_PurchaseOrderReturnID_seq");

            modelBuilder.HasSequence("shippingsuppliers_suppid_seq").StartsAt(3);

            modelBuilder.HasSequence("suppliers_suppid_seq");

            modelBuilder.HasSequence("taxsetting_taxid_seq");

            modelBuilder.HasSequence("transactiondetails_id_seq");

            modelBuilder.HasSequence("transactionid_seq").StartsAt(15);

            modelBuilder.HasSequence("unitrelation_id_seq");

            modelBuilder.HasSequence("units_id_seq");

            modelBuilder.HasSequence("user_id_seq");

            modelBuilder.HasSequence("user_Id_seq");
        }
    }
}
