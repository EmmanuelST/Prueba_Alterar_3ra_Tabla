using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedidos;

namespace Entidades.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void GuardarArtiuloTest()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();

            Articulos entity = new Articulos()
            {
                ArticuloId = 0,
                Descripcion = "Prueba1",
                Existencia = 5,
                Precio = 500
            };

            Assert.IsTrue(db.Guardar(entity));
        }

        [TestMethod()]
        public void GuardarPedidosTest()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();
            List<PedidosDetalle> Detalle = new List<PedidosDetalle>();

            Detalle.Add(new PedidosDetalle() {
                Id = 0,
                ArticuloId = 1,
                PedidoId = 0,
                Cantidad = 5,
                Precio = 500
            });

            Detalle.Add(new PedidosDetalle()
            {
                Id = 0,
                ArticuloId = 2,
                PedidoId = 0,
                Cantidad = 4,
                Precio = 400
            });

            Pedidos entity = new Pedidos()
            {
                PedidoId = 0,
                Fecha = DateTime.Now,
                Monto = 500,
                Detalle = Detalle
                
            };

            Assert.IsTrue(db.Guardar(entity));
        }

        [TestMethod()]
        public void BuscarArtiuloTest()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();

            Articulos entity = new Articulos()
            {
                ArticuloId = 1,
                Descripcion = "Prueba1",
                Existencia = 5,
                Precio = 500
            };

            Assert.IsNotNull(db.Buscar(entity.ArticuloId));
        }

        [TestMethod()]
        public void BuscarPedidoTest()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();

            Pedidos entity = new Pedidos()
            {
                PedidoId = 1,
                Fecha = DateTime.Now,
                Monto = 500
            };

            Assert.IsNotNull(db.Buscar(entity.PedidoId));
        }

        [TestMethod()]
        public void GetListArticuloTest()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();

            

            Assert.IsNotNull(db.GetList(A => true));
        }

        [TestMethod()]
        public void GetListPedidoTest()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();



            Assert.IsNotNull(db.GetList(A => true));
        }

        [TestMethod()]
        public void ModificarArticuloTest()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();

            Articulos entity = new Articulos()
            {
                ArticuloId = 1,
                Descripcion = "Prueba2",
                Existencia = 5,
                Precio = 500
            };
            Assert.IsNotNull(db.Modificar(entity));
        }

        [TestMethod()]
        public void ModificarPedidoTest()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();

            Pedidos entity = new Pedidos()
            {
                PedidoId = 1,
                Fecha = DateTime.Now,
                Monto = 500

            };


            Assert.IsNotNull(db.Modificar(entity));
        }

        [TestMethod()]
        public void EliminarPedidoTest()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();


            Assert.IsNotNull(db.Elimimar(1));
        }

        [TestMethod()]
        public void EliminarArticuloTest()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();


            Assert.IsNotNull(db.Elimimar(1));
        }
    }
}