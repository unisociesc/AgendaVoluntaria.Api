import csv
import requests
import simplejson as json


url = "https://agendavoluntaria.herokuapp.com/api/Auth/login"
data = {'email': 'ghmeyer0@gmail.com', 'password': 'teste@uni'}
headers = {'Content-type': 'application/json'}
r = requests.post(url, data=json.dumps(data), headers=headers)
responseData = r.json()
token = responseData['data']['token']

string_authorization = ('Bearer %s') % token




headers = {'accept': 'application/json', 'Authorization': string_authorization, 'Content-type': 'application/json'}
with open('users-simplificado.tsv','rb') as csvfile:
	reader = csv.DictReader(csvfile, delimiter='\t')
	for row in reader:
		#ADICIONA O USUARIOS
		print "Adicionando: ", row['nome'],row['cpf'],row['email']
		url = "https://agendavoluntaria.herokuapp.com/api/Users"
		data = {'email': row['email'], 'password': row['cpf'], 'name': row['nome'], 'cpf': row['cpf'], 'phone': row['telefone']}
		r = requests.post(url, data=json.dumps(data), headers=headers)
		responseData = r.json()
		idUsuario = responseData['data']['id']
		#ADICIONA OS VOLUNTEERs
		if 'Psico' in row['curso']:
			print 'PSICOLOGO'
			url = "https://agendavoluntaria.herokuapp.com/api/Psicos"
			data = {'idUser': idUsuario}
		else:
			url = "https://agendavoluntaria.herokuapp.com/api/Volunteers"
			data = {'ra': int(row['ra']), 'course': row['curso'], 'needPsico': False, 'idUser': idUsuario}
		r = requests.post(url, data=json.dumps(data), headers=headers)
		print "RESPOSTA:", r.json()


