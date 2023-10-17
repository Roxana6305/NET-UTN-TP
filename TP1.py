def traducir(palabra):
    # Convertir todo a minúsculas
    palabra = palabra.lower()
    traduccion = []
    primera_vocal_duplicada = False

    for letra in palabra:
        if es_vocal(letra):
            if not primera_vocal_duplicada or (len(traduccion) > 0 and not es_vocal(traduccion[-1])):
                traduccion.append(letra * 2)
                primera_vocal_duplicada = True
            else:
                traduccion.append(letra)
        else:
            traduccion.append(letra)

    if len(traduccion) > 6:
        traduccion.insert(0, "an")

    ultima_letra = traduccion[-1]
    if ultima_letra in ['n', 's'] or es_vocal(ultima_letra):
        traduccion.append("so" if ultima_letra == 'o' else "sten")

    return ''.join(traduccion)

def es_vocal(letra):
    return letra in 'aeiou'

frases_criollo = [
    "Hola, amigo",
    "Esto es una prueba",
    "Vocal",
    "Perros",
    "Nave"
]

frases_traducidas = []

for frase in frases_criollo:
    frases_traducidas.append(traducir(frase))

print("Texto en español criollo y su traducción a castellano profundo:")
for i in range(len(frases_criollo)):
    print(f"{frases_criollo[i]} -> {frases_traducidas[i]}")
