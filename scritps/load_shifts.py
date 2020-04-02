import csv
import requests
import simplejson as json
from datetime import datetime, timedelta, date



#url = "https://agendavoluntaria.herokuapp.com/api/Auth/login"
#data = {'email': 'ghmeyer0@gmail.com', 'password': 'teste@uni'}
#headers = {'Content-type': 'application/json'}
#r = requests.post(url, data=json.dumps(data), headers=headers)
#responseData = r.json()
#print responseData
#token = responseData['data']['token']

token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImdobWV5ZXIwQGdtYWlsLmNvbSIsInJvbGUiOiJ2b2x1bnRlZXJzIiwiSWRVc2VyIjoiMDAwMjAwMDAtYWMxMS0wMjQyLWE5MjUtMDhkN2Q1MzY4ZDY5IiwibmJmIjoxNTg1Njk2OTUxLCJleHAiOjE1ODU4NDgxNTEsImlhdCI6MTU4NTY5Njk1MX0.zRZ2r17JeCzL_BDl25LRxAby6CNHcxnqZIPjfDVr4lA'
string_authorization = ('Bearer %s') % token

manhaIni = datetime(2020, 4, 1, 8, 0, 0, 0)
manhaFim = datetime(2020, 4, 1, 12, 0, 0, 0)
tardeIni = datetime(2020, 4, 1, 12, 0, 0, 0)
tardeFim = datetime(2020, 4, 1, 16, 0, 0, 0)
noiteIni = datetime(2020, 4, 1, 16, 0, 0, 0)
noiteFim = datetime(2020, 4, 1, 20, 0, 0, 0)



headers = {'accept': 'application/json', 'Authorization': string_authorization, 'Content-type': 'application/json'}
url = "https://agendavoluntaria.herokuapp.com/api/Shifts"
delta = timedelta(days=1)
for i in range(0,15):
	print "Inserindo entrada", i
	data = {'begin':manhaIni.isoformat(), 'end':manhaFim.isoformat(), 'maxVolunteer': 20}
	r = requests.post(url, data=json.dumps(data), headers=headers)
	data = {'begin':tardeIni.isoformat(), 'end':tardeFim.isoformat(), 'maxVolunteer': 20}
	r = requests.post(url, data=json.dumps(data), headers=headers)
	data = {'begin':noiteIni.isoformat(), 'end':noiteFim.isoformat(), 'maxVolunteer': 20}
	r = requests.post(url, data=json.dumps(data), headers=headers)
	manhaIni += delta
	manhaFim += delta
	tardeIni += delta
	tardeFim += delta
	noiteIni += delta
	noiteFim += delta




