WRITEUP=ProbStatement

all:
	make tex

tex:
	latex $(WRITEUP).tex
	dvips $(WRITEUP).dvi
	ps2pdf $(WRITEUP).ps
	cp -f $(WRITEUP).pdf ~/public_html
	chmod a+r ~/public_html/$(WRITEUP).pdf

clean:
	rm -f *.out *.log *.dvi *.aux *.ps *.pdf *.o *.blg *.bbl
	