'use client';

import { useState, useEffect } from 'react';
import { PlayerListResponse } from './models/player';
import { PlayerList } from './components/PlayerList';

export default function Home() {
  const [loading, setLoading] = useState(true);
  const [lastUpdated, setLastUpdated] = useState<Date | null>(null);
  const [data, setData] = useState<PlayerListResponse>({ players: [] });

  useEffect(() => {
    const fetchData = async () => {
      const response = await fetch('/api/mc/list');
      const data: PlayerListResponse = await response.json();
      
      setData(data);
      setLoading(false);
      setLastUpdated(new Date());
    };
    fetchData();
  }, []);

  return (
    <div className="flex flex-col items-start min-h-screen p-8">
      <h1 className="text-2xl font-bold mb-4">Online Players</h1>
      {
        loading && <p>Loading...</p>
      }
      {
        !loading && data.players.length === 0 && <p>No players online.</p>
      }
      {
        !loading && data.players.length > 0 && <PlayerList data={data} />
      }

    {
      lastUpdated && (
        <p className="text-sm text-gray-500 mt-4">
          Last updated: {lastUpdated.toLocaleTimeString()}
        </p>
      )
    }
    </div>
  );
}


