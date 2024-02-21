<h1>api/cocktails/getall</h1>
# Request: 
<p>curl -X <p >'GET'</p> \
  'https://localhost:1337/api/cocktails/getall' \
  -H 'accept: */*'</p>
# Respone: 
<p>[ <br/>
  {<br/>
    "id": 1,<br/>
    "cocktailName": "Олег",<br/>
    "authorName": "Название!",<br/>
    "powerId": 2,<br/>
    "ingredients": [<br/>
      {<br/>
        "name": "Апельсиновый сок",<br/>
        "image": "Хранить в base64",<br/>
        "powerId": 1,<br/>
        "id": 1<br/>
      },<br/>
      {<br/>
        "name": "Пиво",<br/>
        "image": "Хранить в base64",<br/>
        "powerId": 2,<br/>
        "id": 2<br/>
      }<br/>
    ]<br/>
  }<br/>
]</p>

<h1>api/cocktails/addcocktail</h1>
# Request: 
<p>curl -X 'POST' \<br/>
  'https://localhost:1337/api/cocktails/addcocktail' \<br/>
  -H 'accept: */*' \<br/>
  -H 'Content-Type: application/json' \<br/>
  -d '{<br/>
  "id": 0,<br/>
  "name": "Название",<br/>
  "description": "Описание!",<br/>
  "authorUsername": "Нейм автора!",<br/>
  "ingredientsId": [<br/>
    1, 2<br/>
  ]<br/>
}'</p>
# Responce:
<p>Название успешно добавлен!</p>

<h1>api/cocktails/getbyid?Id={id}</h1>
# Request: 
<p>curl -X 'GET' \<br/>
  'https://localhost:1337/api/cocktails/getbyid?Id=1' \<br/>
  -H 'accept: */*'</p><br/>
# Responce:
<p>{<br/>
  "id": 1,<br/>
  "cocktailName": "Олег",<br/>
  "authorName": "Название!",<br/>
  "powerId": 2,<br/>
  "ingredients": [<br/>
    {<br/>
      "name": "Пиво",<br/>
      "image": "Хранить в base64",<br/>
      "powerId": 2,<br/>
      "id": 2<br/>
    }<br/>
  ]<br/>
}</p>
