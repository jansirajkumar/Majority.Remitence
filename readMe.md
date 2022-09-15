# Money Remittance Service
This service contains set of Web Api's to help sending money in a secured way.

## Tech Stack
* Visual Studio 2022
* .NET Core 6
* SQL Server

# Technical documentation
## Architecture
* The application designed and developed based on DDD design pattern.
* The application is separated into API, Application, Domain and Infrastructure layers. 
* CQRS pattern followed to seperate read and write operations
* Mediatr used for handling Request/Response messages and Notification messages
* EntityFramework used for database operations

### API
* This thin layer is responsible for exposing endpoints. 
* Api versioning enabled for all the endpoints to support backward compatability, adapt new versioning to business requirements etc.
* All the endpoints details can be referred in [ApiRefernce Section](#api-reference)

### Application
This is where Query and Command handlers reside. The responsibility of those is to build responses needed by the API by using one or many Domain Entites. It can do basic logic like summarizing etc, but more advanced business logic should be kept within Domain .

### Domain
Advanced business logic kept in the layer, in well-defined method that does a single thing. 

### Infrastructure
All repository implementations sit in this layer.

### Testing
Two seperate projects are created for testing the methods in the Application project and Infrastructure project.

### Packages & Framework used
1. Meditr 
2. FluentValidation
3. AutoMapper
4. XUnit
5. FluentAssertions
6. EntityFramework

## Run Locally

* Clone the project open in visual studio
* Update the connection string in the appsettings.json
* If need update the accessKey value in the appsettings.json

* Create database open Package Manager console
```bash
  add-migration InitialCreate
  update-database
```
* Run the project. 
* Executing the Api's from browser ensure **accessKey** attribute in the header.

* This Service followed DDD design pattern and principles
* CQRS 

## API Reference
All the Apis requried **AccessKey** parameter to be added in the header

### Get all countries
#### No input parameter to get the country list.

```http
  GET /api/v1/get-country-list
```
### Get all states of the given country code input.

```http
  GET /api/v1/country/{countryCode}/get-state-list
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `countryCode`      | `string` | **Required**. CountryCode to fetch the states of the country |

#### Get exchange rate between different currencies

```http
  GET /api/v1/exchangeRate/get-exchange-rates
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `from`      | `string` | from - from currency code is optional. No input provided **USD** taken as default value |
| `to`      | `string` | **Required**. Multiple currency code could be supplied as comma seperated values **Ex(USD,GDB,SE)**  |

#### Get fees & available transfer mode between the source and destination country. 
```http
  GET /api/v1/fees/get-fees-list
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `from`      | `string` | **Required** from - Source Country Code|
| `to`      | `string` | **Required**. to - Destination Country Code  |

#### Get list of banks available in the given country. 

```http
  GET /api/v1/bank/get-bank-list
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `code`      | `string` | **Required** code - Country code (Ex.US,SE,NO)|

#### Get Beneficiary name based on the accountNumber and bank code. 

```http
  GET /api/v1/bank/get-bank-list
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `accountNumber`      | `string` | **Required** accountNumber |
| `bankCode`      | `string` | **Required** bankCode |

#### Get Beneficiary name based on the accountNumber and bank code. 

```http
  GET /api/v1/bank/get-beneficiary-name
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `accountNumber`      | `string` | **Required** accountNumber |
| `bankCode`      | `string` | **Required** bankCode |

#### Submit Transaction - Initiate money transfer.

```http
  POST /api/v1/transaction/submit-transaction
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `senderFirstName`      | `string` | **Required**  |
| `senderLastName`      | `string` | **Required**  |
| `senderEmail`      | `string` | **Required**  |
| `senderPhoneNumber`      | `string` | **Required**  |
| `address`      | `string` | **Required**  |
| `senderCountry`      | `string` | **Required**  It should follow ISO ALPHA-2 Ex. United States Of America - US|
| `sendFromState`      | `string` | **Required** 2-Letter code |
| `senderCity`      | `string` | **Required**  |
| `senderPostalCode`      | `string` | **Required**  |
| `dateOfBirth`      | `string` | **Required**  Format: YYYY-MM-DD |
| `toFirstName`      | `string` | **Required**  |
| `toLastName`      | `string` | **Required**  |
| `toCountry`      | `string` | **Required**  It should follow ISO ALPHA-2 Ex. United States Of America - U|
| `toBankAccountName`      | `string` | **Required**  |
| `toBankAccountNumber`      | `string` | **Required**  |
| `toBankName`      | `string` | **Required**  |
| `toBankCode`      | `string` | **Required**  |
| `fromAmount`      | `Number` | **Required**  |
| `exchangeRate`      | `Number` | **Required**  |
| `fees`      | `Number` | **Required**  Default 0|
| `transactionNumber`      | `string` | **Required** 10-25 Character |
| `fromCurrency`      | `string` | **Required**  Currency code Ex. USD, SEK, NOK etc|

#### Get Transaction status of the given transaction Id. 

```http
  GET /api/v1/transaction/get-transaction-status
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `transactionId`      | `string` | **Required**  |

### HTTP Status code handled as part of Api responses
200 - Success
201 - Created
202 - Canceled
203 - Declined
401 - Unautorised
440 - Failed request
503 - Service unavailable













