import random

# Enumeraciones para representar tamaños de asteroides y tipos de metales.
class TamañoAsteroides:
    Pequeño, Mediano, Grande, Cataclísmico = range(4)

# Enumeración para tipos de metales.
class TipoMetales:
    Hierro, Oro, Platino, MetalesMisceláneos = range(4)

def obtener_nombre_tamaño(tamaño):
    nombres = ["Pequeño", "Mediano", "Grande", "Cataclísmico"]
    return nombres[tamaño]

def generar_composicion_aleatoria(tamaño, rand):
    composicion = [0, 0, 0, 0]
    total_carga = 0

    # Valores para los diferentes tamaños de asteroides.
    valores_min = [100, 500, 1000, 2500]
    valores_max = [500, 1000, 2500, 5000]

    # Valores aleatorios de metales.
    for i in range(len(composicion)):
        composicion[i] = rand.randint(valores_min[tamaño], valores_max[tamaño] + 1)
        total_carga += composicion[i]

    # Asegurarse de que la carga total sea la especificada para el tamaño del asteroide.
    if total_carga != obtener_carga_tamaño(tamaño):
        # Ajustar la composición para que sume la carga correcta.
        factor_de_ajuste = obtener_carga_tamaño(tamaño) / total_carga
        for i in range(len(composicion)):
            composicion[i] = int(composicion[i] * factor_de_ajuste)

    return composicion

def obtener_carga_tamaño(tamaño):
    cargas = [1000, 2000, 5000, 10000]
    return cargas[tamaño]

def imprimir_composicion(composicion):
    nombres_metal = ["Hierro", "Oro", "Platino", "Metales Misceláneos"]
    for i in range(len(composicion)):
        print(f"{composicion[i]} KG de {nombres_metal[i]}")

def main():
    rand = random.Random()
    sistema_actual = 0
    total_hierro = 0
    total_oro = 0
    total_platino = 0
    total_metales_miscelaneos = 0
    total_carga = 0

    while True:
        sistema_actual += 1
        asteroides_en_sistema = rand.randint(1, 10)  # Generar una cantidad aleatoria de asteroides (entre 1 y 10).

        print(f"EN EL SISTEMA [{sistema_actual}] SE MINARON [{asteroides_en_sistema}] ASTEROIDES")

        for i in range(asteroides_en_sistema):
            # Generar tamaño aleatorio para el asteroide.
            tamaño = rand.choice(list(TamañoAsteroides))
            composicion = generar_composicion_aleatoria(tamaño, rand)

            print(f"{obtener_nombre_tamaño(tamaño)} asteroide:")
            imprimir_composicion(composicion)

            # Actualizar la carga.
            total_hierro += composicion[TipoMetales.Hierro]
            total_oro += composicion[TipoMetales.Oro]
            total_platino += composicion[TipoMetales.Platino]
            total_metales_miscelaneos += composicion[TipoMetales.MetalesMisceláneos]
            total_carga += sum(composicion)

        print(f"Por un total de {total_carga} KG de carga.\n")

        respuesta = input("¿Desea entrar en otro sistema? (S para sí, cualquier otra tecla para salir del programa): ")
        if respuesta.lower() != 's':
            break

    print("RESUMEN TOTAL:")
    print(f"Hierro total: {total_hierro} KG")
    print(f"Oro total: {total_oro} KG")
    print(f"Platino total: {total_platino} KG")
    print(f"Metales misceláneos total: {total_metales_miscelaneos} KG")
    print(f"Carga total: {total_carga} KG")

if __name__ == "__main__":
    main()