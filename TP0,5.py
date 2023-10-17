# Inicialización de variables
dinero_en_caja = 1000.0  # Iniciar con 1000 pesos en caja
comida_gatos_en_stock = 100.0  # Iniciar con 100 kg de comida para gatos en stock
comida_perros_en_stock = 100.0  # Iniciar con 100 kg de comida para perros en stock

print("Selecciona una empleada (1: Andurias, 2: Asterios, 3: Penurias):")
opcion = int(input())

if opcion == 1:
    # Andurias puede modificar el dinero en la caja
    print("Introduce la cantidad de dinero que deseas modificar (positiva para aumentar, negativa para reducir):")
    cantidad_modificar = float(input())
    dinero_en_caja += cantidad_modificar
elif opcion == 2:
    # Asterios puede reducir la cantidad de comida para gatos o perros en stock
    print("Selecciona el tipo de comida para reducir (1: Gatos, 2: Perros):")
    tipo_comida = int(input())
    print("Introduce la cantidad de kilos a reducir:")
    cantidad_reducir = float(input())

    if tipo_comida == 1:
        comida_gatos_en_stock -= cantidad_reducir
    elif tipo_comida == 2:
        comida_perros_en_stock -= cantidad_reducir
    else:
        print("Opción no válida.")
elif opcion == 3:
    # Penurias puede comprar comida para gatos o perros, reduciendo el dinero en la caja
    print("Selecciona el tipo de comida para comprar (1: Gatos, 2: Perros):")
    tipo_comida = int(input())
    print("Introduce la cantidad de kilos a comprar:")
    cantidad_comprar = float(input())

    if tipo_comida == 1:
        costo_compra = cantidad_comprar * 50.0
        if dinero_en_caja >= costo_compra:
            comida_gatos_en_stock += cantidad_comprar
            dinero_en_caja -= costo_compra
        else:
            print("No hay suficiente dinero en la caja para realizar la compra.")
    elif tipo_comida == 2:
        costo_compra = cantidad_comprar * 50.0
        if dinero_en_caja >= costo_compra:
            comida_perros_en_stock += cantidad_comprar
            dinero_en_caja -= costo_compra
        else:
            print("No hay suficiente dinero en la caja para realizar la compra.")
    else:
        print("Opción no válida.")
else:
    print("Opción no válida. Por favor, selecciona 1, 2 o 3.")

# Mostrar el estado actual de stock y dinero en caja
print(f"Stock de comida para gatos: {comida_gatos_en_stock} kg")
print(f"Stock de comida para perros: {comida_perros_en_stock} kg")
print(f"Dinero en caja: {dinero_en_caja} pesos")
