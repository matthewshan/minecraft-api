package main

import "net/http"

func main() {
	mux := http.NewServeMux()

	mux.Handle("/", &handler{})

	http.ListenAndServe(":8080", mux)
}

type handler struct{}

func (h *handler) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	w.Write([]byte("Hello World"))
}
