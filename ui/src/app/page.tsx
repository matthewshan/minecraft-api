'use client';

import { useState, useEffect } from 'react';
import { PlayerListResponse } from './models/player';

export default function Home() {
  const [data, setData] = useState<PlayerListResponse>({ players: [] });

  useEffect(() => {
    const fetchData = async () => {
      const response = await fetch('/api/mc/list');
      const data: PlayerListResponse = await response.json();
      
      setData(data);
    };
    fetchData();
  }, []);

  return (
    <div className="flex flex-col items-start min-h-screen p-8">
      <h1 className="text-2xl font-bold mb-4">Online Players</h1>
      {data && data.players.length > 0 ? ( 
      <div className="space-y-4">
      {data.players.map((player) => (
      <div key={player.uuid} className="flex items-center gap-2">
        <img src={`https://mc-heads.net/avatar/${player.uuid}`} className="w-8 h-8"></img> 
        <span>{player.username}</span>
      </div>
      ))}
      </div>
      ) : (
      <p>No players online.</p>
      )}
    </div>
  );
}
