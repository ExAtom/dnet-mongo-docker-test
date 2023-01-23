#!/bin/sh
sudo docker compose down --volumes
sudo docker compose up -d --build
