using Practica1;
using System.Collections.Generic;

List<Proveedor> proveedores = new List<Proveedor>();
List<Producto> productos = new List<Producto>();
List<OrdenDeCompra> ordenes = new List<OrdenDeCompra>();
Inventario inventario = new Inventario(); 
List<ListaItem> itemsOrden = new List<ListaItem>();

bool menu = true;

do
{
    MostrarMenu();
    menu = ProcesarOpcionMenu(proveedores, productos, ordenes, inventario);

} while (menu);

static void MostrarMenu() 
{
    Console.WriteLine("\n=== MENU PRINCIPAL ===");
    Console.WriteLine("1. Registrar proveedor");
    Console.WriteLine("2. Registrar producto");
    Console.WriteLine("3. Crear orden de compra");
    Console.WriteLine("4. Visualizar ordenes existentes");
    Console.WriteLine("5. Gestionar inventario");
    Console.WriteLine("6. Salir de la aplicacion");
}

bool ProcesarOpcionMenu(List<Proveedor> proveedores, List<Producto> productos, List<OrdenDeCompra> ordenDeCompras, Inventario inventario)
{
    try
    {
        Console.Write("Seleccione una opción ");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                Proveedor.RegistrarProveedor(proveedores);
                break;
            case 2:
                if (proveedores.Count == 0)
                {
                    Console.WriteLine("Debe registrar al menos un proveedor antes de registrar productos.\n");
                    break;
                }

                Producto nuevoproducto = new Producto("", "", 0);
                nuevoproducto.RegistrarProducto(productos, proveedores); // 👈 Se pasa lista de proveedores

                inventario.AgregarProducto(nuevoproducto);
                break;
            case 3:
<<<<<<< HEAD
                if (proveedores.Count == 0)
                {
                    Console.WriteLine("No hay proveedores registrados\n");
                    break;
                }

=======
>>>>>>> implementada capacidad para tener 2 productos iguales, pero de diferente proveedor y diferente precio para comparar
                if (productos.Count == 0)
                {
                    Console.WriteLine("No hay productos registrados\n");
                    break;
                }

                //Se selección de proveedor
                Proveedor proveedorTemporal = new Proveedor("", 0, 0);
                proveedorTemporal.SeleccionarProveedor(proveedores);

                OrdenDeCompra nuevaOrden = new OrdenDeCompra(ordenes.Count + 1, DateTime.Now);
<<<<<<< HEAD
                nuevaOrden.ProveedorSeleccionado = proveedorTemporal.ProveedorSeleccionado;

                //se crear la lista de items y se agrega productos
                List<ListaItem> itemsOrden = new List<ListaItem>();
                Producto productoTemp = new Producto("", "", 0);
                productoTemp.AgregarProductos(productos, itemsOrden);

                nuevaOrden.ListaItems = itemsOrden;
=======
                nuevaOrden.AgregarProductos(productos);
>>>>>>> implementada capacidad para tener 2 productos iguales, pero de diferente proveedor y diferente precio para comparar

                ordenes.Add(nuevaOrden);

                Console.WriteLine("La orden de compra fue creada correctamente\n");
                break;

            case 4:
                OrdenDeCompra.VisualizarOrdenesCompra(ordenes);
                break;
            case 5:
                GestionInventario(inventario, ordenes);
                break;
            case 6:
                Console.WriteLine("Programa finalizado.");
                return false;
            default:
                Console.WriteLine("Opcion no valida, por favor seleccione una opcion del 1 al 6");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Entrada no valida, por favor ingrese un numero del 1 al 6");
    }

    return true; //para que se siga mostrando el menu
}

void GestionInventario(Inventario inventario, List<OrdenDeCompra> ordenes)
{
    bool submenu = true;

    while (submenu)
    {
        try
        {
            Console.WriteLine("\n===Gestion de inventario===");
            Console.Write("1. Mostrar inventario\n");
            Console.Write("2. Actualizar inventario\n");
            Console.Write("3. Salir de gestión de inventario\n");

            Console.WriteLine("Seleccione una de las opciones ");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    inventario.MostrarInventario();
                    break;

                case 2:
                  Inventario.ActualizarOrdenesInventario(inventario, ordenes);
                    break;

                case 3:
                    submenu = false;
                    break;

                default:
                    Console.WriteLine("Opción invalida");
                    break;
            }
        }
        catch(FormatException)
        {
            Console.WriteLine("Error. Solo se permiten números validos ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
