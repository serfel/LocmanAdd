import sys

BSL = chr(92)   # backslash
QT = chr(34)    # double quote


def get_js(src):
    start = src.index('return ' + QT) + len('return ' + QT)
    end = src.rindex(QT + ';')
    body = src[start:end]

    segs = []
    i, n = 0, len(body)
    while i < n:
        if body[i] == QT:
            j = i + 1
            buf = []
            while j < n:
                c = body[j]
                if c == BSL and j + 1 < n:
                    buf.append(BSL)
                    buf.append(body[j + 1])
                    j += 2
                elif c == QT:
                    break
                else:
                    buf.append(c)
                    j += 1
            segs.append(''.join(buf))
            i = j + 1
        else:
            i += 1

    def unesc(s):
        out = []
        i = 0
        while i < len(s):
            c = s[i]
            if c == BSL and i + 1 < len(s):
                ch = s[i + 1]
                mapping = {'n': chr(10), 't': chr(9), 'r': chr(13),
                           QT: QT, chr(39): chr(39), BSL: BSL}
                out.append(mapping.get(ch, BSL + ch))
                i += 2
            else:
                out.append(c)
                i += 1
        return ''.join(out)

    return ''.join(unesc(s) for s in segs)


if __name__ == '__main__':
    sys.stdout.write(get_js(open(sys.argv[1], encoding='utf-8').read()))
