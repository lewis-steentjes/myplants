import Image from "next/image";
import Picker from "./_components/Picker";
export default function Home() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <Picker/>
    </main>
  );
}
