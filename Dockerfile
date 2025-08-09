# Stage 1: Builder
FROM golang:1.24.6-alpine AS builder

WORKDIR /app

COPY go.mod ./
# COPY go.sum ./
RUN go mod download

# Copy the rest of the application source code
COPY . .

# Build the Go application
RUN go build -o main ./...

# Stage 2: Runner
FROM alpine:latest

WORKDIR /app/

# Copy the compiled binary from the builder stage
COPY --from=builder /app/main .

# Expose the port your application listens on (if it's a web service)
EXPOSE 8080

# Command to run the application when the container starts
CMD ["./main"]