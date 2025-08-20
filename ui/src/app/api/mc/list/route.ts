import { PlayerListResponse } from '@/app/models/player';
import axios from 'axios';
import { NextResponse } from 'next/server';

const MINECRAFT_API_URL = process.env.MINECRAFT_API_URL;

export async function GET() {
    try {
        const uri = `${MINECRAFT_API_URL}/api/players`;
        if (!MINECRAFT_API_URL) {
            throw new Error("MINECRAFT_API_URL is not defined in environment variables");
        }

        console.log(`Listing players from Minecraft API: '${uri}'`);
        const response = await axios.get(`${MINECRAFT_API_URL}/api/players`);
        return NextResponse.json<PlayerListResponse>(response.data);
    } catch (error) {
        console.error("Error listing players:", error);
        return new NextResponse("Internal Server Error", { status: 500 });
    }
}