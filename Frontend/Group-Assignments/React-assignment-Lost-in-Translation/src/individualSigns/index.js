import a from '../individualSigns/a.png';
import b from '../individualSigns/b.png';
import c from '../individualSigns/c.png';
import d from '../individualSigns/d.png';
import e from '../individualSigns/e.png';
import f from '../individualSigns/f.png';
import g from '../individualSigns/g.png';
import h from '../individualSigns/h.png';
import i from '../individualSigns/i.png';
import j from '../individualSigns/j.png';
import k from '../individualSigns/k.png';
import l from '../individualSigns/l.png';
import m from '../individualSigns/m.png';
import n from '../individualSigns/n.png';
import o from '../individualSigns/o.png';
import p from '../individualSigns/p.png';
import q from '../individualSigns/q.png';
import r from '../individualSigns/r.png';
import s from '../individualSigns/s.png';
import t from '../individualSigns/t.png';
import u from '../individualSigns/u.png';
import v from '../individualSigns/v.png';
import w from '../individualSigns/w.png';
import x from '../individualSigns/x.png';
import y from '../individualSigns/y.png';
import z from '../individualSigns/z.png';
export const changeLetterToSign = (inputLetter) => {
    switch (inputLetter) {
        case "a": return a;
        case "b": return b;
        case "c": return c;
        case "d": return d;
        case "e": return e;
        case "f": return f;
        case "g": return g;
        case "h": return h;
        case "i": return i;
        case "j": return j;
        case "k": return k;
        case "l": return l;
        case "m": return m;
        case "n": return n;
        case "o": return o;
        case "p": return p;
        case "q": return q;
        case "r": return r;
        case "s": return s;
        case "t": return t;
        case "u": return u;
        case "v": return v;
        case "w": return w;
        case "x": return x;
        case "y": return y;
        case "z": return z;
        default: return a;
    }
}

export default changeLetterToSign;