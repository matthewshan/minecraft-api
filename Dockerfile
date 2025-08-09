# Stage 1: Builder
FROM golang:1.24.6-alpine AS builder

WORKDIR /app

# Copy go.mod and go.sum first to leverage Docker's cache
COPY go.mod ./
# COPY go.sum ./
RUN go mod download

# Copy the rest of the application source code
COPY . .

# Build the Go application
# CGO_ENABLED=0 disables CGO, creating a statically linked binary
# -o specifies the output binary name
# ./... builds all packages in the current directory and its subdirectories
RUN CGO_ENABLED=0 GOOS=linux go build -a -installsuffix cgo -o main ./...

# Stage 2: Runner
FROM alpine:latest

WORKDIR /root/

# Copy the compiled binary from the builder stage
COPY --from=builder /app/main .

# Expose the port your application listens on (if it's a web service)
EXPOSE 8080

# Command to run the application when the container starts
CMD ["./main"]