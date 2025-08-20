import { Rcon } from 'rcon/node-rcon';
import { NextResponse } from 'next/server';

const server = process.env.MC_SERVER;
const port = process.env.MC_RCON_PORT; 
const password = process.env.MC_RCON_PASSWORD;

const options = {
  tcp: true,      
  challenge: false
};


export async function GET(request: Request) {
    try {
        console.log("Connecting to RCON server:", server, "on port:", port);
        const conn = new Rcon(server, port, password, options);

        conn.on('auth', function() {
            conn.send("list");
        }).on('response', function(str) {
            console.log("Response: " + str);
        }).on('error', function(err) {
            console.log("Error: " + err);
        }).on('end', function() {
            console.log("Connection closed");
            process.exit();
        });

        conn.connect();

        return NextResponse.json({});
    } catch (error) {
        console.error("Error executing command:", error);
        return NextResponse.json(
            { error: 'Failed to execute command' },
            { status: 500 }
        );
    }
}