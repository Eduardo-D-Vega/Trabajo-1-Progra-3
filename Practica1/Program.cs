using Practica1;

List<Proveedor> proveedores = new List<Proveedor>();
List<Producto> productos = new List<Producto>();
List<OrdenDeCompra> ordenes = new List<OrdenDeCompra>();
List<ListaItem> cantidadProducto = new List<ListaItem>(); 

bool menu = true;

do
{
    MostrarMenu();
    menu = ProcesarOpcionMenu(proveedores, productos, ordenes);

} while (menu);

static void MostrarMenu() 
{
    Console.WriteLine("\n=== MENU PRINCIPAL ===");
    Console.WriteLine("1. Registrar proveedor");
    Console.WriteLine("2. Registrar producto");
    Console.WriteLine("3. Crear orden de compra");
    Console.WriteLine("4. Visualizar ordenes existentes");
    Console.WriteLine("5. Actualizar inventario");
    Console.WriteLine("6. Salir de la aplicacion");
}

bool ProcesarOpcionMenu(List<Proveedor> proveedores, List<Producto> productos, List<OrdenDeCompra> ordenDeCompras)
{
    try
    {
        Console.Write("Seleccione una opción: ");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                //Proveedor nuevoProveedor = new Proveedor();
                //nuevoProveedor.AgregarProveedor(proveedores);
                break;
            case 2:
                //RegistrarProducto(productos);
                break;
            case 3:
                if (proveedores.Count == 0)
                {
                    Console.WriteLine("\nDebe registrar un proveedor antes de crear una orden de compra\n");
                    break; //vuelve al menu
                }

                if (productos.Count == 0)
                {
                    Console.WriteLine("\nLa lista de productos esta vacía, agregue productos antes\n");
                    break; 
                }

                OrdenDeCompra nuevo = new OrdenDeCompra(ordenes.Count + 1, DateTime.Now);
                nuevo.SeleccionarProveedor(proveedores);
                nuevo.AgregarProductos(productos, cantidadProducto);

                decimal ValorTotal = 0;
                ValorTotal = nuevo.ValorTotalOrdenCompra(cantidadProducto);
                Console.WriteLine($"El valor de la orden de compra es de: {ValorTotal}");
                ordenes.Add(nuevo);
                Console.WriteLine("\nLa orden de compra fue creada correctamente\n");
                break;
            case 4:
                // Visualizar ordenes
                break;
            case 5:
                //ActualizarInventario
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