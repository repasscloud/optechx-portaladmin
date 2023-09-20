#!/usr/bin/env zsh

# Check if the "ngrok" network exists
if ! docker network inspect ngrok &>/dev/null; then
  # If the network doesn't exist, create it
  echo "Creating 'ngrok' network..."
  docker network create ngrok
else
  echo "'ngrok' network already exists."
fi

# Function to start the Docker container
start_container() {
  echo "Starting Docker container..."
  docker build --rm -t optechx-portaladmin:dev .
  docker run --rm --detach \
  --name portaladmin \
  --network ngrok \
  optechx-portaladmin:dev >/dev/null 2>&1
}

# Function to stop the Docker container if it's running
stop_container() {
  echo "Stopping the running container (if any)..."
  docker stop portaladmin >/dev/null 2>&1 || true
  docker stop ngrok >/dev/null 2>&1 || true
}

# Function to remove any dangling or leftover containers
cleanup_containers() {
  echo "Cleaning up dangling or leftover containers..."
  docker ps -aq -f status=exited | xargs docker rm -v >/dev/null 2>&1 || true
}

# Main script
cleanup_containers
stop_container
start_container

# Start ngrok
docker run --rm --detach \
--name ngrok \
--network ngrok \
-v $(pwd)/etc/ngrok.yaml:/etc/ngrok.yaml \
-e NGROK_CONFIG=/etc/ngrok.yaml \
ngrok/ngrok:alpine \
start --all
