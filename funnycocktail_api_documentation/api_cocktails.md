<h1>api/cocktails/getall</h1>
# Request: 
<p>curl -X <p >'GET'</p> \
  'https://localhost:1337/api/cocktails/getall' \
  -H 'accept: */*'</p>
# Respone: 
<p>[
  {
    "id": 1,
    "cocktailName": "Олег",
    "authorName": "Название!",
    "powerId": 2,
    "ingredients": [
      {
        "name": "Апельсиновый сок",
        "image": "Хранить в base64",
        "powerId": 1,
        "id": 1
      },
      {
        "name": "Пиво",
        "image": "Хранить в base64",
        "powerId": 2,
        "id": 2
      }
    ]
  }
]</p>

<h1>api/cocktails/addcocktail</h1>
# Request: 
<p>curl -X 'POST' \
  'https://localhost:1337/api/cocktails/addcocktail' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 0,
  "name": "Название",
  "description": "Описание!",
  "authorUsername": "Нейм автора!",
  "ingredientsId": [
    1, 2
  ]
}'</p>
# Responce:
<p>Название успешно добавлен!</p>

<h1>api/cocktails/getbyid?Id=1</h1>
# Request: 
<p>curl -X 'GET' \
  'https://localhost:1337/api/cocktails/getbyid?Id=1' \
  -H 'accept: */*'</p>
# Responce:
<p>{
  "id": 1,
  "cocktailName": "Олег",
  "authorName": "Название!",
  "powerId": 2,
  "ingredients": [
    {
      "name": "Пиво",
      "image": "Хранить в base64",
      "powerId": 2,
      "id": 2
    }
  ]
}</p>