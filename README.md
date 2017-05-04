# ASPNETCORE-SPA-Demo
Demonstration for ASP.NET Core on OpenShift


# Run on OpenShift

See the [repo](https://github.com/tanaka-takayoshi/mssql-server-rhel/tree/dev) to run SQL Server on RHEL docker.

```
$ export SQLSRV_NAME=SQLSERVER_RHEL_DEV
$ oadm policy add-scc-to-user anyuid -z default
$ oc new-app https://github.com/tanaka-takayoshi/mssql-server-rhel.git#openshift --name $SQLSRV_NAME
$ oc env dc $SQLSRV_NAME ACCEPT_EULA=Y SA_PASSWORD=<PassWord>
// Now log into the DB, create database and table, insert sample rows.
$ oc rsh <sqlserver_pod_name> 


$ export APP_NAME=spademo
$ oc new-app dotnet/dotnetcore-11-rhel7~https://github.com/tanaka-takayoshi/ASPNETCORE-SPA-Demo.git 
$ oc create secret generic db-secret --from-literal=SQLDB_USER=<DB_USER> --from-literal=SQLDB_PASSWORD=<DB_PASSWORD>
$ oc set env dc/$APP_NAME SQLDB_SVC_NAME=$SQLSRV_NAME ASPNETCORE_ENVIRONMENT=Production
$ oc set env --from=secret/db-secret dc/$APP_NAME
```