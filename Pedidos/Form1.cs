using Entidades.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pedidos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}

namespace Entidades
{
    public class Pedidos
    {
        [Key]
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        [ForeignKey("ArticuloId")]
        public virtual List<PedidosDetalle> Detalle { get; set; }

        public Pedidos()
        {
            this.Detalle = new List<PedidosDetalle>();
        }
        public void AgregarDetalle(PedidosDetalle pedido)
        {
            this.Detalle.Add(pedido);
        }
    }

    public class PedidosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ArticuloId { get; set; }
        public decimal Cantidad { get; set; }
        public double Precio { get; set; }

        public PedidosDetalle()
        {
            Id = 0;
            PedidoId = 0;
            ArticuloId = 0;
            Cantidad = 0;
            Precio = 0;
        }
    }

    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public decimal Existencia { get; set; }
        public decimal Precio { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Precio = 0;
        }
    } 

    namespace DAL
    {
        public class Contexto : DbContext
        {
            public DbSet<Pedidos>Pedido { get; set; }
            public DbSet<Articulos>Articulo { get; set; }

            public Contexto() : base(@"Data Source=.\SqlExpress;Initial Catalog = RepasoDb; Integrated Security = True")
            {

            }
        }
    }

    namespace BLL
    {
        public interface IRepository<T> where T : class
        {
            List<T> GetList(Expression<Func<T, bool>> Expression);
            T Buscar(int id);
            bool Guardar(T entity);
            bool Modificar(T entity);
            bool Elimimar(int id);
        }

        public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
        {

            internal Contexto db;

            public RepositorioBase()
            {
                db = new Contexto();
            }
            public virtual bool Guardar(T entity)
            {
                bool paso = false;

                try
                {
                    if (db.Set<T>().Add(entity) != null)
                        paso = db.SaveChanges() > 0;

                }
                catch (Exception)
                {
                    throw;
                }


                return paso;
            }

            public virtual bool Modificar(T entity)
            {
                bool paso = false;

                try
                {

                    db.Entry(entity).State = EntityState.Modified;
                    paso = db.SaveChanges() > 0;

                }
                catch (Exception)
                {
                    throw;
                }


                return paso;
            }
            public T Buscar(int id)
            {
                T entity;

                try
                {
                    entity = db.Set<T>().Find(id);

                }
                catch (Exception)
                {
                    throw;
                }


                return entity;
            }
            public List<T> GetList(Expression<Func<T, bool>> expression)
            {
                List<T> lista;

                try
                {
                    lista = db.Set<T>().Where(expression).ToList();

                }
                catch (Exception)
                {
                    throw;
                }


                return lista;
            }
            
            public void Dispose()
            {
                db.Dispose();
            }

            public bool Elimimar(int id)
            {
                bool paso = false;
                T entity;

                try
                {
                    entity = db.Set<T>().Find(id);
                    db.Entry(entity).State = EntityState.Deleted;
                    paso = db.SaveChanges() > 0;

                }
                catch (Exception)
                {
                    throw;
                }


                return paso;
            }
        }

        public class PedidoRepositorio : RepositorioBase<Pedidos>
        {

            
        }

    }



}
