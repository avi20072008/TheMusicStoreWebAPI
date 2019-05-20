# TheMusicStoreWebAPI

The Music Store is a RESTful web service developed using ASP.Net WEB API & C#.

This web-service has songs database. This API provides different operations as given below,

1) Sort Songs by given field name 

API Endpoint
>/api/songs/sortBy/{fieldName}


Request Method
>GET


- Sort by Artist : /api/songs/sortBy/Artist


- Sort by song Title : /api/songs/sortBy/Title


- Sort by ReleaseYear : /api/songs/sortBy/ReleaseYear




2) Search songs between given years. 


 API Endpoint
  api/songs/search/{fromYear:int},{toYear:int}


 Request Method
    GET


 Get songs between 1940 & 1970
  /api/songs/search/1940,1970




3) Get All Songs	


 API Endpoint
  /api/songs


 Request Method
    GET


 Get all songs
  /api/songs/


 
4) Get specific song
		

 API Endpoint
  /api/songs/{id}


 Request Method
    GET


 search song for the id 7
  /api/songs/7


 
5) Create a new song 

 API Endpoint
  /api/songs/


 Request Method
    POST


 search song for the id 7
  /api/songs/
[ send Song object as param ]


6) Update existing song

 API Endpoint
  /api/songs/{id}


 Request Method
    PUT


 update song for the id 7
  /api/songs/7
[ send Song object as param ]



7) Delete existing song

 API Endpoint
  /api/songs/{id}


 Request Method
    DELETE


 delete song for the id 7
  /api/songs/7
[ send Song object as param ]

