import random

# Enumeración para tipos de metales.
class TipoMetales:
    Hierro, Oro, Platino, MetalesMisceláneos = range(4)

# Clase para representar un asteroide con su tamaño y composición.
class Asteroide:
    def __init__(self, tamaño):
        self.tamaño = tamaño
        self.composicion = self.generar_composicion_aleatoria()
    
    def generar_composicion_aleatoria(self):
        composicion = [0, 0, 0, 0]
        total_carga = 0

        valores_min = [100, 500, 1000, 2500]
        valores_max = [500, 1000, 2500, 5000]

        # Generar valores aleatorios de metales para la composición del asteroide.
        for i in range(len(composicion)):
            composicion[i] = random.randint(valores_min[self.tamaño], valores_max[self.tamaño] + 1)
            total_carga += composicion[i]

        # Asegurarse de que la carga total sea la especificada para el tamaño del asteroide.
        factor_de_ajuste = obtener_carga_tamaño(self.tamaño) / total_carga
        for i in range(len(composicion)):
            composicion[i] = int(composicion[i] * factor_de_ajuste)

        return composicion

    def obtener_nombre_tamaño(self):
        nombres = ["Pequeño", "Mediano", "Grande", "Cataclísmico"]
        return nombres[self.tamaño]

    def imprimir_composicion(self):
        nombres_metal = ["Hierro", "Oro", "Platino", "Metales Misceláneos"]
        for i in range(len(self.composicion)):
            print(f"{self.composicion[i]} KG de {nombres_metal[i]}")

# Función para obtener la carga específica para un tamaño de asteroide.
def obtener_carga_tamaño(tamaño):
    cargas = [1000, 2000, 5000, 10000]
    return cargas[tamaño]

def main():
    sistema_actual = 0
    total_hierro = 0
    total_oro = 0
    total_platino = 0
    total_metales_miscelaneos = 0
    total_carga = 0

    while True:
        sistema_actual += 1
        asteroides_en_sistema = random.randint(1, 10)  

        print(f"EN EL SISTEMA [{sistema_actual}] SE MINARON [{asteroides_en_sistema}] ASTEROIDES")

        for i in range(asteroides_en_sistema):
            tamaño = random.choice(list(range(4)))  # Generar tamaño aleatorio para el asteroide.
            asteroide = Asteroide(tamaño)

            print(f"{asteroide.obtener_nombre_tamaño()} asteroide:")
            asteroide.imprimir_composicion()

            total_hierro += asteroide.composicion[TipoMetales.Hierro]
            total_oro += asteroide.composicion[TipoMetales.Oro]
            total_platino += asteroide.composicion[TipoMetales.Platino]
            total_metales_miscelaneos += asteroide.composicion[TipoMetales.MetalesMisceláneos]
            total_carga += sum(asteroide.composicion)

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