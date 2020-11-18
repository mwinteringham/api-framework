package main

import (
	"bytes"
	"encoding/json"
	"flag"
	"fmt"

	//	"log"
	"net/http"
	"os"
	"testing"
	"time"

	"github.com/Rosalita/api-framework/go/api"
	"github.com/Rosalita/api-framework/go/payloads"
)

func TestMain(m *testing.M) {

	flag.Parse()
	// Test setup

	// Run tests
	exitCode := m.Run()

	// Test teardown
	os.Exit(exitCode)
}

var (
	client     *http.Client
	authCookie string
)

func init() {
	client = &http.Client{
		Timeout: 10 * time.Second,
	}

	tokenReq, err := api.RequestAuth("admin", "password123")
	if err != nil {
		fmt.Println(err)
	}

	_, body := DoRequest(tokenReq)

	var authResp payloads.AuthResponse
	json.Unmarshal([]byte(body), &authResp)
	authCookie = fmt.Sprintf("token=%s", authResp.Token)
}

// DoRequest makes a request returning the Status Code and the Response
func DoRequest(req *http.Request) (statuscode int, reponse string) {
	resp, err := client.Do(req)
	if err != nil {
		fmt.Println(err)
	}
	defer resp.Body.Close()
	var buffer bytes.Buffer
	if _, err := buffer.ReadFrom(resp.Body); err != nil {
		fmt.Println(err)
	}

	return resp.StatusCode, buffer.String()
}
