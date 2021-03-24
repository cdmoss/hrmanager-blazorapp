#!/bin/bash
cd /c/Users/Chase/Desktop/Programming/hrmanager-blazorapp/
./runapi.sh &> /c/Users/Chase/Desktop/Programming/hrmanager-blazorapp/debug-logs/api.log & 
./runblazor.sh &> /c/Users/Chase/Desktop/Programming/hrmanager-blazorapp/debug-logs/blazor.log & 
./runidp.sh &> /c/Users/Chase/Desktop/Programming/hrmanager-blazorapp/debug-logs/idp.log