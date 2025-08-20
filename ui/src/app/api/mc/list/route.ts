import { PlayerListResponse } from '@/app/models/player';
import axios from 'axios';
import { NextResponse } from 'next/server';

const MINECRAFT_API_URL = process.env.MINECRAFT_API_URL;

export async function GET() {
    try {
        const response = await axios.get(`${MINECRAFT_API_URL}/api/players`);
        return NextResponse.json<PlayerListResponse>(response.data);
    } catch (error) {
        console.error("Error listing players:", error);
        return new NextResponse("Failed to list players", { status: 500 });
    }
}